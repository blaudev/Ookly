using Ookly.Core.AdAggregate;

namespace Ookly.Core.AdDocumentAggregate;

public interface IAdDocumentRepository
{
    Task<bool> AddAsync(AdDocument adDocument);
    Task<List<Ad>> SearchAsync();
    Task<bool> DeleteAdIndexAsync();
    Task<bool> CreateIndexAsync();
}
