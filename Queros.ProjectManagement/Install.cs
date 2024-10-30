using Microsoft.Extensions.DependencyInjection;
using Queros.ProjectManagement.Processors;
using Queros.ProjectManagement.Services;

namespace Queros.ProjectManagement;

public static class Install
{
    public static IServiceCollection AddProjectManagementServices(this IServiceCollection services)
    {
        services.AddScoped<IHashingService, HashingService>();
        services.AddScoped<ITokenServiceProvider, TokenServiceProvider>();
        services.AddScoped<ProjectService>();
        services.AddScoped<ProjectTaskService>();
        services.AddScoped<AuthenticationService>();
        return services;
    }
}