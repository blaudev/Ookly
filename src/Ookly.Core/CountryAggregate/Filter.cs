namespace Ookly.Core.CountryAggregate;

public class Filter(string categoryId, string filterTypeId) : Entity<string>($"{categoryId}_{filterTypeId}")
{
    public Filter(Category category, FilterType filterType) : this(category.Id, filterType.Id)
    {
        Category = category;
        FilterType = filterType;
    }

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public string FilterTypeId { get; private set; } = filterTypeId;
    public FilterType FilterType { get; private set; } = default!;

    public List<Facet> Facets { get; private set; } = [];

    public void AddFacet(Facet facet)
    {
        Facets.Add(facet);
    }

    public void AddFacets(List<Facet> facets)
    {
        Facets.AddRange(facets);
    }
}
