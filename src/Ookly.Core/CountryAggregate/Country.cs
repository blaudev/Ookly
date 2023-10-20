using Blau.Entities;

using Ookly.Core.CategoryAggregate;

namespace Ookly.Core.CountryAggregate;

public class Country(string name) : Entity, IAggregateRoot
{
    public string Name { get; private set; } = name;

    public List<Category> Categories { get; private set; } = default!;

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

    public void AddCategories(IEnumerable<Category> categories)
    {
        Categories.AddRange(categories);
    }
}
