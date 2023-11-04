namespace Ookly.Core.Entities.ListingEntity;

public class ListingDetailType(string id) : Entity<string>(id)
{
    public List<Category> CategoryTypes { get; private set; } = [];
}
