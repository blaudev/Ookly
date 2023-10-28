namespace Ookly.Core.AdDocumentAggregate;

public class AdDocument(string id, string title) : Entity<string>(id), IAggregateRoot
{
    public string Title { get; private set; } = title;
}
