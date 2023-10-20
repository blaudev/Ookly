using Ookly.Core.AdAggregate;

namespace Ookly.Core.CategoryAggregate;

public class Category
{
    private Category() { }

    public Category(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public IReadOnlyList<Ad> Ads { get; private set; } = default!;
}
