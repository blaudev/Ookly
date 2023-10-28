namespace Ookly.Core.AdDocumentAggregate;

public class AdDocument(string id) : Entity<string>(id), IAggregateRoot
{
}
