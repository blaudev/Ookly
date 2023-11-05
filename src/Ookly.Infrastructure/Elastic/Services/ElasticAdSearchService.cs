using Nest;

using Ookly.Core.Entities;
using Ookly.Core.Entities.ListingEntity;
using Ookly.Core.Services.AdSearchService;
using Ookly.Core.Services.SearchService.Models;

namespace Ookly.Infrastructure.Elastic.Services;

public class ElasticAdSearchService(ElasticClient client) : IAdSearchService
{

    private readonly string _aggregatePropertiesName = "props";
    private readonly string _aggregateNamesName = "names";
    private readonly string _aggregateTextValues = "text_values";
    private readonly string _aggregateNumericValues = "numeric_values";

    public async Task<SearchResponse> SearchAsync(List<Filter> filters)
    {
        var filterSorts = filters.ToDictionary(k => k.Id, v => v.SortType);

        var sd = new SearchDescriptor<Listing>();

        sd.Size(10);
        sd = BuildQuery(sd);
        sd = BuildAggregates(sd, []);

        var response = await client.SearchAsync<Listing>(sd);

        var buckets = GetBuckets(response);
        var filterBuckets = ExcludeFilterBuckets(buckets, filters);
        var facets = GetFacets(filterBuckets, filters);
        var sortedFacets = OrderFacets(facets, filterSorts);

        return new SearchResponse(sortedFacets);
    }

    private static SearchDescriptor<Listing> BuildQuery(SearchDescriptor<Listing> descriptor) =>
        descriptor.Query(q => q.MatchAll());

    private List<string> GetExcludeAggregations(List<FilterValueType> filters) =>
        [.. filters.Select(f => f.Id)];

    private SearchDescriptor<Listing> BuildAggregates(SearchDescriptor<Listing> descriptor, List<string> exclude) =>
        descriptor
            .Aggregations(a => a
                .Nested(_aggregatePropertiesName, n => n
                    .Path(p => p.Properties)
                    .Aggregations(aa => aa
                        .Terms(_aggregateNamesName, t => t
                            .Field(p => p.Properties.Suffix("filterId"))
                            .Exclude(exclude)
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

    private List<KeyedBucket<string>> GetBuckets(ISearchResponse<Listing> response) =>
        [.. response
            .Aggregations
            .Nested(_aggregatePropertiesName)
            .Terms(_aggregateNamesName)
            .Buckets
        ];

    private static IEnumerable<KeyedBucket<string>> ExcludeFilterBuckets(IEnumerable<KeyedBucket<string>> buckets, List<FilterValueType> filters) =>
        buckets.Where(q => filters.Any(f => f.Id == q.Key));

    private List<Facet> GetFacets(IEnumerable<KeyedBucket<string>> buckets, List<FilterValueType> filters) =>
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

    private static List<Facet> OrderFacets(List<Facet> facets, Dictionary<string, FilterSortType> filterSorts) =>
        [.. facets.Select(f => f with { Items = OrderItems(f.Items, filterSorts[f.FilterId]) })];

    private static List<FacetItem> OrderItems(IEnumerable<FacetItem> items, FilterSortType sortType) =>
        sortType switch
        {
            FilterSortType.FilterIdAsc => [.. items.OrderBy(o => o.Key)],
            FilterSortType.FilterIdDesc => [.. items.OrderByDescending(o => o.Key)],
            FilterSortType.DocCountAsc => [.. items.OrderBy(o => o.Count)],
            FilterSortType.DocCountDesc => [.. items.OrderByDescending(o => o.Count)],
            _ => throw new NotImplementedException(),
        };

    private static QueryContainer BuildQuery()
    {
        var query = new QueryContainer();
        return query;
    }
}
