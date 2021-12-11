using GFTTechnicalTestAPP.Application.Interfaces;
using GFTTechnicalTestAPP.Application.Services;
using GFTTechnicalTestAPP.Infrastructure.ExternalServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GFTTechnicalTestAPP.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection serviceCollections)
        {
            serviceCollections.AddScoped<IOrderExternalService, OrderExternalService>();
            serviceCollections.AddScoped<IOrdersService, OrdersService>();
        }
    }
}
