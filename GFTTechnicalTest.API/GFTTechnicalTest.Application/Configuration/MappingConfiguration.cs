using GFTTechnicalTest.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace GFTTechnicalTest.Application.Configuration
{
    public static class MappingConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection serviceCollections)
        {
            serviceCollections.AddAutoMapper(typeof(OrderInputModelProfile), typeof(OrderResponseModelProfile));
        }
    }
}
