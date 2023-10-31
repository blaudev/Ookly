using Blau.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Ookly.Infrastructure.EntityFramework;
using Ookly.Infrastructure.EntityFramework.InMemory;
using Ookly.Infrastructure.EntityFramework.Postgres;
using Ookly.Infrastructure.Options;

namespace Ookly.Infrastructure;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var options = services.ConfigureRequiredOptions<DatabaseOptions>(configuration);

        if (options.DatabaseType == DatabaseType.Postgres)
        {
            PostgresDatabase(services, configuration);
            return services;
        }

        InMemoryDatabase(services, configuration);
        return services;
    }

    private static void PostgresDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var options = services.ConfigureRequiredOptions<PostgresOptions>(configuration);
        services.AddDbContext<ApplicationContext>(ob => ob.UseNpgsql(options.ConnectionString));
    }

    private static void InMemoryDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var options = services.ConfigureRequiredOptions<InMemoryOptions>(configuration);
        services.AddDbContext<ApplicationContext>(ob => ob.UseInMemoryDatabase(options.ConnectionString));
    }
}
