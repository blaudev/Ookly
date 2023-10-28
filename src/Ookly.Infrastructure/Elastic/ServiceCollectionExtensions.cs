using Elasticsearch.Net;

using Microsoft.Extensions.Configuration;

using Nest;

using Ookly.Core.AdDocumentAggregate;
using Ookly.Infrastructure.Elastic;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddElasticClient(this IServiceCollection services, IConfiguration configuration)
    {

        var options = configuration.GetSection("Elastic").Get<ElasticOptions>() ?? throw new ArgumentException(nameof(ElasticOptions));
        var pool = new SingleNodeConnectionPool(options.Uri);

        var settings = new ConnectionSettings(pool)
            .DefaultMappingFor<AdDocument>(x => x
                .IndexName(options.IndexName)
                .IdProperty("Id"));

        var client = new ElasticClient(settings);
        services.AddSingleton(client);

        if (client.Indices.Exists(options.IndexName).Exists)
        {
            client.Indices.Create(options.IndexName, c => c
                .Map<AdDocument>(m => m
                    .AutoMap()
                    .Properties(p => p
                        .Text(t => t
                            .Name(n => n.Title)
                            .Analyzer("spanish")
                        )
                    )
                )
            );
        }

        return services;
    }
}
