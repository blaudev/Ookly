using Microsoft.Extensions.Options;

using Nest;

using Ookly.Core.Entities.ListingEntity;
using Ookly.Core.Services.AdElasticIndexService;

namespace Ookly.Infrastructure.Elastic;

public class ElasticAdIndexService(ElasticClient client, IOptions<ElasticOptions> elasticOptions) : IElasticAdIndexService
{
    private readonly ElasticOptions options = elasticOptions.Value;

    public async Task<bool> CreateIndexAsync()
    {
        var map = await client.Indices.CreateAsync(options.Index, c => c
            .Map<Listing>(m => m
                .AutoMap()
                .Properties(ps => ps
                    .Text(p => p.Name(n => n.Title).Analyzer("spanish"))
                    .Keyword(p => p.Name(n => n.CountryId))
                    .Keyword(p => p.Name(n => n.CategoryId))
                    .Nested<ListingDetail>(n => n
                        .Name(n => n.Details)
                        .Properties(ps => ps
                            .Keyword(p => p.Name(n => n.FilterId))
                            .Keyword(p => p.Name(n => n.TextValue))
                            .Number(p => p.Name(n => n.NumericValue))
                            .Boolean(p => p.Name(n => n.BooleanValue))
                        )
                    )
                )
            )
        );

        return map.IsValid;
    }

    public async Task<bool> DeleteIndexAsync()
    {
        var response = await client.Indices.DeleteAsync(options.Index);
        return response.IsValid;
    }

    public async Task<bool> AddAdAsync(Listing ad)
    {
        var response = await client.IndexAsync(ad, i => i.Index(options.Index));
        return response.IsValid;
    }
}

