using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Ookly.Infrastructure.EntityFramework;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetSection("Database").GetSection("DatabaseType").Value == "InMemory")
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase("OoklyDb");
            });
        }
        else
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("OoklyDb"));
            });
        }

        return services;
    }
}
