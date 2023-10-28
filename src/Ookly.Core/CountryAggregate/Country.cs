namespace Ookly.Core.CountryAggregate;

public class Country(string id) : Entity<string>(id), IAggregateRoot
{
    public List<Category> Categories { get; private set; } = [];

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

}
