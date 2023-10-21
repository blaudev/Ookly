using Blau.Entities;

using Ookly.Core.CategoryAggregate;

namespace Ookly.Core.CountryAggregate;

public class Country(Guid id, string name) : Entity(id), IAggregateRoot
{
    public string Name { get; private set; } = name;

    public List<Category> Categories { get; private set; } = [];

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

    public void AddCategories(IEnumerable<Category> categories)
    {
        Categories.AddRange(categories);
    }
}
