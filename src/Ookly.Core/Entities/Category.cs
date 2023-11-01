namespace Ookly.Core.Entities;

public class Category(string id) : Entity<string>(id)
{
    public List<CountryCategory> CountryCategories { get; private set; } = [];
}
