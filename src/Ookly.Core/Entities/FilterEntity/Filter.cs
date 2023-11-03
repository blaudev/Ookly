using Ookly.Core.Entities.AdEntity;
using Ookly.Core.Entities.CategoryEntity;
using Ookly.Core.Entities.CountryEntity;

namespace Ookly.Core.Entities.FilterEntity;

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

public class Filter(string id, FilterType valueType, SortType sortType, int order, string categoryId, string? parentId)
    : Entity<string>(id)
{
    public Filter(string id, FilterType valueType, SortType sortType, int order, Category category, Filter? parent)
        : this(id, valueType, sortType, order, category.Id, parent?.Id)
    {
        Category = category;
        Parent = parent;
    }

    public FilterType ValueType { get; private set; } = valueType;
    public SortType SortType { get; private set; } = sortType;
    public int Order { get; private set; } = order;

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public string? ParentId { get; private set; } = parentId;
    public Filter? Parent { get; private set; } = default!;

    public List<CategoryFilter> CategoryFilters { get; private set; } = [];
    public List<AdProperty> AdProperties { get; private set; } = [];
}
