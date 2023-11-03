using Ookly.Core.Entities.AdEntity;

namespace Ookly.Core.Services.AdElasticIndexService;

public interface IElasticAdIndexService
{
    Task<bool> CreateIndexAsync();
    Task<bool> DeleteIndexAsync();
    Task<bool> AddAdAsync(Ad ad);
}
