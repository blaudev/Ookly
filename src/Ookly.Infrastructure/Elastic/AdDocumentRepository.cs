using Microsoft.Extensions.Options;

using Nest;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.Elastic;

public class AdDocumentRepository(ElasticClient client, IOptions<ElasticOptions> elasticOptions) : IAdDocumentRepository
{
    private readonly ElasticOptions options = elasticOptions.Value;

    public async Task<List<Ad>> SearchAsync(List<Core.Entities.Filter> filters)
    {
        var sd = new SearchDescriptor<Ad>();

        sd.Size(10);

        sd.Query(q => q.MatchAll());

        sd = sd
            .Aggregations(a => a
                .Nested("props", n => n
                    .Path(p => p.Properties)
                    .Aggregations(aa => aa
                        .Terms("names", t => t
                            .Field(p => p.Properties.Suffix("filterId"))
                            .Aggregations(aa => aa
                                .Terms("text_values", t => t
                                    .Field(f => f.Properties.Suffix("textValue"))
                                )
                                .Terms("numeric_values", t => t
                                    .Field(f => f.Properties.Suffix("numericValue"))
                                )
                            )
                        )
                    )
                )
            );


        var resp = await client.SearchAsync<Ad>(sd);

        var aggregates = resp
            .Aggregations
            .Nested("props")
            .Terms("names")
            .Buckets
            .ToDictionary(
                k => k.Key,
                v => v.Terms("text_values").Buckets
                .Concat(v.Terms("numeric_values").Buckets)
                .ToDictionary(k => k.Key, v => v.DocCount ?? 0)
            );

        var facets = filters
            .ToDictionary(
                k => k.Id,
                v => v.SortType switch
                {
                    SortType.FilterIdAsc => aggregates[v.Id].OrderBy(o => o.Key),
                    SortType.FilterIdDesc => aggregates[v.Id].OrderByDescending(o => o.Key),
                    SortType.DocCountAsc => aggregates[v.Id].OrderBy(o => o.Value),
                    SortType.DocCountDesc => aggregates[v.Id].OrderByDescending(o => o.Value),
                    _ => throw new NotImplementedException(),
                });

        return new List<Ad>();
    }

    static QueryContainer BuildQuery()
    {
        var query = new QueryContainer();

        return query;
    }


    public async Task<bool> AddAsync(Ad ad)
    {
        var response = await client.IndexAsync(ad, i => i.Index(options.Index));
        return response.IsValid;
    }

    public async Task<bool> DeleteAdIndexAsync()
    {
        var response = await client.Indices.DeleteAsync(options.Index);
        return response.IsValid;
    }

    public async Task<bool> CreateIndexAsync()
    {
        var map = await client.Indices.CreateAsync(options.Index, c => c
            .Map<Ad>(m => m
                .AutoMap()
                .Properties(ps => ps
                    .Text(p => p.Name(n => n.Title).Analyzer("spanish"))
                    .Keyword(p => p.Name(n => n.CountryId))
                    .Keyword(p => p.Name(n => n.CategoryId))
                    .Nested<AdProperty>(n => n
                        .Name(n => n.Properties)
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
}
