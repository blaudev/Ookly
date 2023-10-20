using Ookly.Core.AdAggregate;

namespace Ookly.Core.CategoryAggregate;

public class Category
{
    public int Id { get; init; }
    public IReadOnlyList<Ad> Ads { get; init; } = [];
}
