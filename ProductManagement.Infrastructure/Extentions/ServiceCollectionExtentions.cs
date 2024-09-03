using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductManagement.Infrastructure;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddInfrastructureExtentions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductManagementDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyDB")));
        return services;
    }
}
