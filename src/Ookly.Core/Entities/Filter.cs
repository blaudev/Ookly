namespace Ookly.Core.Entities;

public class Filter : Entity
{
    public string Name { get; init; } = string.Empty;

    public int CategoryId { get; init; }
    public Category Category { get; init; } = new();

    public FilterType Type { get; init; }
    public FilterSort Sort { get; init; }
    public int Order { get; init; }

    public int? ParentId { get; init; }
    public Filter? Parent { get; init; } = new();

    public List<CategoryFilter> CategoryFilters { get; init; } = [];
}

public enum FilterType
{
    Text,
    Numeric,
    Boolean
}

public enum FilterSort
{
    FilterNameAsc,
    FilterNameDesc,
    DocCountAsc,
    DocCountDesc
}
