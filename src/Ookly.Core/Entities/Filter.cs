namespace Ookly.Core.Entities;

public enum FilterType
{
    Text,
    Numeric,
    Boolean
}

public class Filter(string id, FilterType valueType, string categoryId) : Entity<string>(id)
{
    public Filter(string id, FilterType valueType, Category category) : this(id, valueType, category.Id)
    {
        Category = category;
    }

    public FilterType ValueType { get; private set; } = valueType;

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public List<CategoryFilter> CategoryFilters { get; private set; } = [];
    public List<AdProperty> AdProperties { get; private set; } = [];
}
