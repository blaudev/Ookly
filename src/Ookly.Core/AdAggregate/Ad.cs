using Ookly.Core.CategoryAggregate;

namespace Ookly.Core.AdAggregate;

public class Ad
{
    public int Id { get; init; }

    public int CategoryId { get; init; }
    public Category Category { get; init; } = new();
}
