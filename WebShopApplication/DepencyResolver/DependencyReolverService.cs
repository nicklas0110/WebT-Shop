

using Microsoft.Extensions.DependencyInjection;
using WebShopApplication.Interfaces;

namespace WebShopApplication.DepencyResolver;

public class DependencyReolverService
{
    public static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IWebShopService, WebShopService>();
    }
}