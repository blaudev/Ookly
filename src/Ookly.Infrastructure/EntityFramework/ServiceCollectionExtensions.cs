using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Ookly.Infrastructure.EntityFramework;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        Action<DbContextOptionsBuilder> options = configuration["Database:DatabaseType"] switch
        {
            "InMemory" => new(options => options.UseInMemoryDatabase("OoklyDb")),
            _ => new(options => options.UseNpgsql(configuration.GetConnectionString("OoklyDb")))
        }

        services.AddDbContext<ApplicationContext>(options);

        return services;
    }
}
