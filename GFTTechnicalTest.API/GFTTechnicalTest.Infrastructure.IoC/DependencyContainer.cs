using GFTTechnicalTest.Application.Interfaces;
using GFTTechnicalTest.Application.Services;
using GFTTechnicalTest.Domain.Repositories;
using GFTTechnicalTest.Infrastructure.Data.Context;
using GFTTechnicalTest.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GFTTechnicalTest.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IOrdersService, OrdersService>();
                        
            // Infra - Data
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<GFTTechnicalTestContext>();

        }
    }
}
