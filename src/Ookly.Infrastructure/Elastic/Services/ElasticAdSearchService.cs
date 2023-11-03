using Nest;

using Ookly.Core.Entities.AdEntity;
using Ookly.Core.Entities.FilterEntity;
using Ookly.Core.Services.AdSearchService;
using Ookly.Core.Services.SearchService.Models;

using FilterEntity = Ookly.Core.Entities.FilterEntity;

namespace Ookly.Infrastructure.Elastic.Services;

public class ElasticAdSearchService(ElasticClient client) : IAdSearchService
{

    private readonly string _aggregatePropertiesName = "props";
    private readonly string _aggregateNamesName = "names";
    private readonly string _aggregateTextValues = "text_values";
    private readonly string _aggregateNumericValues = "numeric_values";

    public async Task<SearchResponse> SearchAsync(List<FilterEntity.Filter> filters)
    {
        var filterSorts = filters.ToDictionary(k => k.Id, v => v.SortType);

        var sd = new SearchDescriptor<Ad>();

        sd.Size(10);
        sd = BuildQuery(sd);
        sd = BuildAggregates(sd);

        var response = await client.SearchAsync<Ad>(sd);

        var buckets = GetBuckets(response);
        var filterBuckets = ExcludeFilterBuckets(buckets, filters);
        var facets = GetFacets(filterBuckets, filters);
        var sortedFacets = OrderFacets(facets, filterSorts);

        return new SearchResponse(sortedFacets);
    }

    private static SearchDescriptor<Ad> BuildQuery(SearchDescriptor<Ad> descriptor) =>
        descriptor.Query(q => q.MatchAll());

    private SearchDescriptor<Ad> BuildAggregates(SearchDescriptor<Ad> descriptor) =>
        descriptor
            .Aggregations(a => a
                .Nested(_aggregatePropertiesName, n => n
                    .Path(p => p.Properties)
                    .Aggregations(aa => aa
                        .Terms(_aggregateNamesName, t => t
                            .Field(p => p.Properties.Suffix("filterId"))
                            .Aggregations(aa => aa
                                .Terms(_aggregateTextValues, t => t
                                    .Field(f => f.Properties.Suffix("textValue"))
                                )
                                .Terms(_aggregateNumericValues, t => t
                                    .Field(f => f.Properties.Suffix("numericValue"))
                                )
                            )
                        )
                    )
                )
            );

    private List<KeyedBucket<string>> GetBuckets(ISearchResponse<Ad> response) =>
        [.. response
            .Aggregations
            .Nested(_aggregatePropertiesName)
            .Terms(_aggregateNamesName)
            .Buckets
        ];

    private static IEnumerable<KeyedBucket<string>> ExcludeFilterBuckets(IEnumerable<KeyedBucket<string>> buckets, List<FilterEntity.Filter> filters) =>
        buckets.Where(q => filters.Any(f => f.Id == q.Key));

    private List<Facet> GetFacets(IEnumerable<KeyedBucket<string>> buckets, List<FilterEntity.Filter> filters) =>
        [.. buckets
            .Select(b =>
                new Facet
                (
                    b.Key,
                    [
                        .. GetFacetItems(b, _aggregateTextValues),
                        .. GetFacetItems(b, _aggregateNumericValues),
                    ]
                )
            )
        ];

    private static IEnumerable<FacetItem> GetFacetItems(KeyedBucket<string> bucket, string key) =>
        bucket.Terms(key).Buckets.Select(i => new FacetItem(i.Key, i.DocCount ?? 0));

    private static List<Facet> OrderFacets(List<Facet> facets, Dictionary<string, SortType> filterSorts) =>
        [.. facets.Select(f => f with { Items = OrderItems(f.Items, filterSorts[f.FilterId]) })];

    private static List<FacetItem> OrderItems(IEnumerable<FacetItem> items, SortType sortType) =>
        sortType switch
        {
            SortType.FilterIdAsc => [.. items.OrderBy(o => o.Key)],
            SortType.FilterIdDesc => [.. items.OrderByDescending(o => o.Key)],
            SortType.DocCountAsc => [.. items.OrderBy(o => o.Count)],
            SortType.DocCountDesc => [.. items.OrderByDescending(o => o.Count)],
            _ => throw new NotImplementedException(),
        };

    private static QueryContainer BuildQuery()
    {
        var query = new QueryContainer();
        return query;
    }
}
