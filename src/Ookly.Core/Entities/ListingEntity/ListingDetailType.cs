namespace Ookly.Core.Entities.ListingEntity;

public class ListingDetailType : Entity
{
    public List<Category> CategoryTypes { get; private set; } = [];
}
