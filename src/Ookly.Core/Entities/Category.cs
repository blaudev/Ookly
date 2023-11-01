namespace Ookly.Core.Entities;

public class Category(string id) : Entity<string>(id)
{
    public List<Filter> Filters { get; private set; } = [];
    public List<CountryCategory> CountryCategories { get; private set; } = [];
}
