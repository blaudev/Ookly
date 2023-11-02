using Blau.Configuration;

using Elasticsearch.Net;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Nest;
using Ookly.Core.Entities.AdEntity;

namespace Ookly.Infrastructure.Elastic;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddElastic(this IServiceCollection services, IConfiguration configuration)
    {
        var options = services.ConfigureRequiredOptions<ElasticOptions>(configuration);
        var pool = new SingleNodeConnectionPool(new Uri(options.ConnectionString));

        var settings = new ConnectionSettings(pool)
            .DisableDirectStreaming()
            .DefaultMappingFor<Ad>(x => x
                .IndexName(options.Index)
                .IdProperty("Id")
                .Ignore(i => i.Country)
                .Ignore(i => i.Category)
            )
            .DefaultMappingFor<AdProperty>(x => x
                .Ignore(i => i.Ad)
                .Ignore(i => i.FilterType)
            );

        var client = new ElasticClient(settings);
        services.AddSingleton(client);

        return services;
    }
}
