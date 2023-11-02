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
        var sd = new SearchDescriptor<Ad>();

        sd.Size(10);

        sd.Query(q => q.MatchAll());

        sd = sd
            .Aggregations(a => a
                .Nested("props", n => n
                    .Path(p => p.Properties)
                    .Aggregations(aa => aa
                        .Terms("properties-names", t => t
                            .Field(p => p.Properties.Suffix("filterId"))
                            .Aggregations(aa => aa
                                .Terms("text-values", t => t
                                    .Field(f => f.Properties.Suffix("textValue"))
                                )
                                .Terms("numeric-values", t => t
                                    .Field(f => f.Properties.Suffix("numericValue"))
                                )
                            )
                        )
                    )
                )
            );


        var resp = await client.SearchAsync<Ad>(sd);

        var p = resp.Aggregations.Nested("props");
        var pn = p.Terms("properties-names");
        //var pn = resp.Aggregations["properties-names"] as TermsAggregate<Ad>;
        var r = pn.Buckets.Select(b =>
        {
            var name = b.Key;
            var textValues = b.Terms("text-values").Buckets.Select(b => (b.Key, b.DocCount)).ToList();
            var numericValues = b.Terms("numeric-values").Buckets.Select(b => (b.Key, b.DocCount)).ToList();

            var values = textValues.Any() ? textValues : numericValues;

            return values;
        }).ToList();

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
