using Microsoft.Extensions.Options;

using Nest;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.Elastic;

public class AdDocumentRepository(ElasticClient client, IOptions<ElasticOptions> elasticOptions) : IAdDocumentRepository
{
    private readonly ElasticOptions options = elasticOptions.Value;

    public async Task<List<Ad>> SearchAsync(CountryCategory countryCategory)
    {
        var req = new SearchRequest<AdDocument>(options.Index)
        {
            Size = 100,
            Aggregations = BuildAggregations(countryCategory.CategoryFilters),
            Query = BuildQuery(),
        };

        var resp = await client.SearchAsync<AdDocument>(req);


        return new List<Ad>();
    }

    public static AggregationDictionary BuildAggregations(List<CategoryFilter> categoryFilters)
    {
        var containers = categoryFilters.Select(x =>
            (
                x.FilterId,
                new AggregationContainer
                {
                    Terms = new TermsAggregation($"{x.FilterId}") { Field = $"properties.{x.FilterId}.keyword" }
                }
            )
        )
        .ToDictionary(x => x.Item1, x => x.Item2);

        var dic = new AggregationDictionary(containers);
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
                .AutoMap()
            )
        );

        return response.IsValid;
    }
}
