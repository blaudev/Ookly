using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Ookly.Infrastructure.Configuration;
using Ookly.Infrastructure.Elastic;
using Ookly.Infrastructure.EntityFramework;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
        var options = configuration.GetSection(DatabaseOptions.SectionName).Get<DatabaseOptions>() ?? throw new Exception($"{nameof(ElasticOptions)} must be configured");

        if (options.DatabaseType == DatabaseType.Postgres)
        {
            PostgresDatabase(services, options);
            return services;
        }

        InMemoryDatabase(services, options);
        return services;
    }

    private static void PostgresDatabase(IServiceCollection services, DatabaseOptions options)
    {
        services.AddDbContext<ApplicationContext>(ob => ob.UseNpgsql(options.ConnectionString));
    }

    private static void InMemoryDatabase(IServiceCollection services, DatabaseOptions options)
    {
        services.AddDbContext<ApplicationContext>(ob => ob.UseInMemoryDatabase(options.Database));
    }
}
