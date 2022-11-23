
using Microsoft.Extensions.DependencyInjection;
using WebShopApplication.Interfaces;
using WebShopInfrastructure;

namespace WebShopInfrastructure.DependencyResolver;

public class DependencyResolverService
{
    public static void RegisterInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IWebShopItemRepository, WebShopRepository>();
    }
} 