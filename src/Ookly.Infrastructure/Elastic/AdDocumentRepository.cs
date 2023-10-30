using Microsoft.Extensions.Options;

using Nest;

using Ookly.Core.AdAggregate;
using Ookly.Core.AdDocumentAggregate;

namespace Ookly.Infrastructure.Elastic;

public class AdDocumentRepository(ElasticClient client, IOptions<ElasticOptions> elasticOptions) : IAdDocumentRepository
{
    private readonly ElasticOptions options = elasticOptions.Value;

    public async Task<List<Ad>> SearchAsync()
    {
        var req = new SearchRequest<AdDocument>(options.IndexName)
        {
            Size = 100,
            Aggregations = BuildAggregations(),
            Query = BuildQuery(),
        };

        var resp = await client.SearchAsync<AdDocument>(req);

        var terms = resp.Aggregations
                    .Terms("filters");

        var filters = resp.Aggregations
                    .Terms("filters")
                    .Buckets
                    .ToList();

        var properties = resp.Aggregations
                    .Terms("properties")
                    .Buckets
                    .ToList();


        return new List<Ad>();
    }

    public static AggregationDictionary BuildAggregations()
    {
        var dic = new AggregationDictionary()
        {
            {
                "filters",
                new AggregationContainer()
                {
                    Nested = new NestedAggregation("properties")
                    {
                        Path = "Properties.keyword",
                    }
                }
            }
        };

        return dic;
    }

    static QueryContainer BuildQuery()
    {
        var query = new QueryContainer();

        return query;
    }


    public async Task AddAsync(AdDocument adDocument)
    {
        await client.IndexDocumentAsync(adDocument);
    }

    public async Task DeleteAdIndexAsync()
    {
        var r = await client.Indices.DeleteAsync(options.IndexName);
    }

    public async Task CreateIndexAsync()
    {
        var r = await client.Indices.CreateAsync(options.IndexName, c => c
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
}
