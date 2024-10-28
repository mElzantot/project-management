using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Queros.ProjectManagement.Data.Repositories;

public class BaseRepository<TContext, TEntity, TId> : IBaseRepository<TEntity, TId> 
    where TContext : DbContext 
    where TEntity : class, new()
{
    private readonly Action<TEntity, TId> _idSetter;
    private readonly TContext _context;

    protected BaseRepository(TContext context, Action<TEntity, TId> idSetter)
    {
        _context = context;
        _idSetter = idSetter;
    }
    
    
    public async Task<List<TResult>> GetAllAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool asNoTracking = true,
        int? skip = null,
        int? limit = null,
        params Expression<Func<TEntity, object>>[] includes)

    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (asNoTracking)
            query = query.AsNoTracking();
            
        if (predicate != null)
            query = query.Where(predicate);

        if (skip != null && limit != null)
            query = query.Skip(skip.Value).Take(limit.Value);
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query
            .Select(selector)
            .ToListAsync();
    }
    
    public async Task<TResult?> GetFirstAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool asNoTracking = true)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (asNoTracking)
            query = query.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        return await query
            .Select(selector)
            .FirstOrDefaultAsync();
    }
    
    public async Task<TResult?> GetSingleAsync<TResult>( 
         Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate,
        bool asNoTracking = true,
        params Expression<Func<TEntity, object>>[] includes)
    {

        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (asNoTracking)
            query = query.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);
            
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query
            .Select(selector)
            .SingleOrDefaultAsync();
    }
    
    public async Task<bool> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(
        TId id,
        Action<TEntity> updateExpression)
    {

        TEntity entity = new();
        _idSetter.Invoke(entity, id);
        _context.Attach(entity);

        updateExpression.Invoke(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _context.Attach(entity);
        _context.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    
}