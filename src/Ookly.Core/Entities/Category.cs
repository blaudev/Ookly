using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Core.Entities;

public class Category : NamedEntity
{
    public List<ListingDetailType> ListingDetailTypes { get; init; } = [];
}
