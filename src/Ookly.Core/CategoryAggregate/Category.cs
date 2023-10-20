using Blau.Entities;

using Ookly.Core.AdAggregate;

namespace Ookly.Core.CategoryAggregate;

public class Category(string name) : Entity<int>, IAggregateRoot
{
    public string Name { get; private set; } = name;
    public IReadOnlyList<Ad> Ads { get; private set; } = default!;
}
