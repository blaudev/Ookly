using Blau.Configuration;

using Elasticsearch.Net;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Nest;

using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Infrastructure.Elastic;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddElastic(this IServiceCollection services, IConfiguration configuration)
    {
        var options = services.ConfigureRequiredOptions<ElasticOptions>(configuration);
        var pool = new SingleNodeConnectionPool(new Uri(options.ConnectionString));

        var settings = new ConnectionSettings(pool)
            .DisableDirectStreaming()
            .DefaultMappingFor<Listing>(x => x
                .IndexName(options.Index)
                .IdProperty("Id")
                .Ignore(i => i.Country)
                .Ignore(i => i.Category)
            )
            .DefaultMappingFor<ListingDetail>(x => x
                .Ignore(i => i.Ad)
                .Ignore(i => i.Filter)
            );

        var client = new ElasticClient(settings);
        services.AddSingleton(client);

        return services;
    }
}
