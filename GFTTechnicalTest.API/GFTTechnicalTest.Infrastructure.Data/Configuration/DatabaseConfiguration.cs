using GFTTechnicalTest.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GFTTechnicalTest.Infrastructure.Data.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GFTTechnicalTestContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
        }

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<GFTTechnicalTestContext>())
                {
                    appContext.Database.Migrate();

                }
            }

            return host;
        }
    }
}
