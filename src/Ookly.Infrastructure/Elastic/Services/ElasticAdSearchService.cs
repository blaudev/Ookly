using Nest;

using Ookly.Core.Entities.AdEntity;
using Ookly.Core.Entities.FilterEntity;
using Ookly.Core.Services.AdSearchService;
using Ookly.Core.Services.SearchService.Models;

using FilterEntity = Ookly.Core.Entities.FilterEntity;

namespace Ookly.Infrastructure.Elastic.Services;

public class ElasticAdSearchService(ElasticClient client) : IAdSearchService
{
    public async Task<SearchResponse> SearchAsync(List<FilterEntity.Filter> filters)
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

        var filterSorts = filters.ToDictionary(k => k.Id, v => v.SortType);

        var response = await client.SearchAsync<Ad>(sd);
        var buckets = GetBuckets(response);
        var filterBuckets = OnlyFilterBuckets(buckets, filters);
        var facets = GetFacets(filterBuckets, filters);
        var sortedFacets = OrderFacets(facets, filterSorts);

        return new SearchResponse(sortedFacets);
    }

    private static SearchDescriptor<Ad> BuildAggregates(SearchDescriptor<Ad> descriptor)
    {
        return descriptor
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
    }

    private static List<Facet> GetFacets(IEnumerable<KeyedBucket<string>> buckets, List<FilterEntity.Filter> filters)
    {
        var filterSorts = filters.ToDictionary(k => k.Id, v => v.SortType);

        return buckets
            .Select(b =>
                new Facet
                (
                    b.Key,
                    [
                        .. GetFacetItems(b, "text_values"),
                        .. GetFacetItems(b, "numeric_values"),
                    ]
                )
            )
            .ToList();
    }

    private static List<Facet> OrderFacets(List<Facet> facets, Dictionary<string, SortType> filterSorts)
    {
        return facets.Select(f => f with { Items = OrderItems(f.Items, filterSorts[f.FilterId]) }).ToList();
    }

    private static List<FacetItem> OrderItems(IEnumerable<FacetItem> items, SortType sortType)
    {
        return sortType switch
        {
            SortType.FilterIdAsc => [.. items.OrderBy(o => o.Key)],
            SortType.FilterIdDesc => [.. items.OrderByDescending(o => o.Key)],
            SortType.DocCountAsc => [.. items.OrderBy(o => o.Count)],
            SortType.DocCountDesc => [.. items.OrderByDescending(o => o.Count)],
            _ => throw new NotImplementedException(),
        };
    }

    private static List<KeyedBucket<string>> GetBuckets(ISearchResponse<Ad> response)
    {
        return response
            .Aggregations
            .Nested("props")
            .Terms("names")
            .Buckets
            .ToList();
    }

    private static IEnumerable<KeyedBucket<string>> OnlyFilterBuckets(IEnumerable<KeyedBucket<string>> buckets, List<FilterEntity.Filter> filters)
    {
        return buckets.Where(q => filters.Any(f => f.Id == q.Key));
    }

    private static IEnumerable<FacetItem> GetFacetItems(KeyedBucket<string> bucket, string key)
    {
        return bucket.Terms(key).Buckets.Select(i => new FacetItem(i.Key, i.DocCount ?? 0));
    }

    private static QueryContainer BuildQuery()
    {
        var query = new QueryContainer();

        return query;
    }
}
