using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Core.Entities;

public class Category : Entity
{
    public string Name { get; init; } = string.Empty;

    public List<ListingDetailType> ListingDetailTypes { get; init; } = [];
}
