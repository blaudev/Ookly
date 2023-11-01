using Blau.Configuration;

using Elasticsearch.Net;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Nest;

namespace Ookly.Infrastructure.Elastic;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddElastic(this IServiceCollection services, IConfiguration configuration)
    {
        var options = services.ConfigureRequiredOptions<ElasticOptions>(configuration);
        var pool = new SingleNodeConnectionPool(new Uri(options.ConnectionString));

        var settings = new ConnectionSettings(pool);
        //.DefaultMappingFor<AdDocument>(x => x
        //    .IndexName(options.Index)
        //    .IdProperty("Id"));

        var client = new ElasticClient(settings);
        services.AddSingleton(client);

        return services;
    }
}
