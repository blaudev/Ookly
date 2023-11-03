using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Core.Services.AdElasticIndexService;

public interface IElasticAdIndexService
{
    Task<bool> CreateIndexAsync();
    Task<bool> DeleteIndexAsync();
    Task<bool> AddAdAsync(Listing ad);
}
