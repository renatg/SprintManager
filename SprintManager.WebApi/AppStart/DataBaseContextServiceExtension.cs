using Microsoft.EntityFrameworkCore;
using SprintManager.Data;
using SprintManager.Data.Repositories;
using SprintManager.Data.Repositories.Interfaces;
using SprintManager.Services.Interfaces;
using SprintManager.Services.Services;

namespace SprintManager.WebApi.AppStart;

public static class DataBaseContextServiceExtension
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("main")));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ISprintRepository, SprintRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<ISprintService, SprintService>();

        return services;
    }
}