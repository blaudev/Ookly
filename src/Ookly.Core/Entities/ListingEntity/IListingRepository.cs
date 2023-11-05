using Blau.Data;

namespace Ookly.Core.Entities.ListingEntity;

public interface IListingRepository : IRepository<Listing>
{
    Task<List<Listing>> SearchAsync(Dictionary<string, string> filters);
}
