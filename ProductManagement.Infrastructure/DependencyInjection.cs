using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Domain.IRepositories;
using ProductManagement.Infrastructure.Repositories;
namespace ProductManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Đăng ký dependencyinjection ở đây
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }

}
