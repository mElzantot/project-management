using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Queros.ProjectManagement.Data.Repositories;

namespace Queros.ProjectManagement.Data;

public static class Install
{
    public static IServiceCollection AddProjectManagementContextServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("projectManagementDb");
        services.AddDbContext<ProjectManagementContext>(options =>
        {
            options
                .UseNpgsql(connectionString, config => config.EnableRetryOnFailure(3))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .ConfigureWarnings(warn =>
                    warn.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning)
                );
        });

        RegisterRepositories(services);
        return services;
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

    }
}