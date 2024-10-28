using System.Linq.Expressions;

namespace Queros.ProjectManagement.Data.Repositories;

public interface IBaseRepository<TEntity, TId>
{
    Task<List<TResult>> GetAllAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool asNoTracking = true,
        int? skip = null,
        int? limit = null,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TResult?> GetFirstAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool asNoTracking = true);

    Task<TResult?> GetSingleAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate,
        bool asNoTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    Task<bool> UpdateAsync(TId id, Action<TEntity> updateExpression);

    Task<bool> AddAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
}