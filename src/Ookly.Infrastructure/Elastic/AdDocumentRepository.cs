using Microsoft.Extensions.Options;

using Nest;
using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.Elastic;

public class AdDocumentRepository(ElasticClient client, IOptions<ElasticOptions> elasticOptions) : IAdDocumentRepository
{
    private readonly ElasticOptions options = elasticOptions.Value;

    public async Task<List<Ad>> SearchAsync()
    {
        var req = new SearchRequest<AdDocument>(options.Index)
        {
            Size = 100,
            Aggregations = BuildAggregations(),
            Query = BuildQuery(),
        };

        var resp = await client.SearchAsync<AdDocument>(req);

        var filters = resp.Aggregations
            .Nested("filters");


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
                        Path = "properties",
                        Aggregations = new AggregationDictionary()
                        {
                            {
                                "name",
                                new TermsAggregation("name")
                                {
                                    Field = "properties.name",
                                    Size = 100
                                }
                            }
                        }
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


    public async Task<bool> AddAsync(AdDocument adDocument)
    {
        var response = await client.IndexAsync(adDocument, i => i.Index(options.Index));
        return response.IsValid;
    }

    public async Task<bool> DeleteAdIndexAsync()
    {
        var response = await client.Indices.DeleteAsync(options.Index);
        return response.IsValid;
    }

    public async Task<bool> CreateIndexAsync()
    {
        var response = await client.Indices.CreateAsync(options.Index, c => c
            .Map<AdDocument>(m => m
                .Properties(p => p
                    .Nested<Property>(n => n
                        .Name(nn => nn.Properties)
                        .Properties(pp => pp
                            .Text(k => k
                                .Name(n => n.Name)
                            )
                            .Keyword(t => t
                                .Name(n => n.Value)
                            )
                        )
                    )
                    .Text(t => t
                        .Name(n => n.Title)
                        .Analyzer("spanish")
                    )
                )
            )
        );

        return response.IsValid;
    }
}
