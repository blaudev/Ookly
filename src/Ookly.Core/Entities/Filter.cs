namespace Ookly.Core.Entities;

public enum FilterType
{
    Text,
    Numeric,
    Boolean
}

public class Filter(string id, FilterType valueType) : Entity<string>(id)
{
    public FilterType ValueType { get; private set; } = valueType;

    public List<CategoryFilter> CategoryFilters { get; private set; } = [];
    public List<AdProperty> AdProperties { get; private set; } = [];
}
