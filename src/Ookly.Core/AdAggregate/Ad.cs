using Ookly.Core.CountryAggregate;

namespace Ookly.Core.AdAggregate;

public class Ad(string title, string description, Guid categoryId) : Entity, IAggregateRoot
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;

    public Guid CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;
}
