using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }
}