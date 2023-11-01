namespace Ookly.Core.Entities;

public class Category(string id) : Entity<string>(id)
{
}

public class CategoryFilter(string categoryId, string filterTypeId) : Entity<string>($"{categoryId}_{filterTypeId}")
{
    public CategoryFilter(CountryCategory category, Filter filterType) : this(category.Id, filterType.Id)
    {
        Category = category;
        FilterType = filterType;
    }

    public string CategoryId { get; private set; } = categoryId;
    public CountryCategory Category { get; private set; } = default!;

    public string FilterTypeId { get; private set; } = filterTypeId;
    public Filter FilterType { get; private set; } = default!;
}
