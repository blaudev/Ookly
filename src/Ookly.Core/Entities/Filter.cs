namespace Ookly.Core.Entities;

public enum FilterType
{
    Text,
    Numeric,
    Boolean
}

public enum SortType
{
    FilterIdAsc,
    FilterIdDesc,
    DocCountAsc,
    DocCountDesc
}

public class Filter(string id, FilterType valueType, SortType sortType, int order, string categoryId) : Entity<string>(id)
{
    public Filter(string id, FilterType valueType, SortType sortType, int order, Category category) : this(id, valueType, sortType, order, category.Id)
    {
        Category = category;
    }

    public FilterType ValueType { get; private set; } = valueType;
    public SortType SortType { get; private set; } = sortType;
    public int Order { get; private set; } = order;

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public List<CategoryFilter> CategoryFilters { get; private set; } = [];
    public List<AdProperty> AdProperties { get; private set; } = [];
}
