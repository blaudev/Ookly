using Ookly.Core.AdAggregate;

namespace Ookly.Core.AdDocumentAggregate;

public interface IAdDocumentRepository
{
    Task AddAsync(AdDocument adDocument);
    Task<List<Ad>> SearchAsync();
    Task DeleteAdIndexAsync();
    Task CreateIndexAsync();
}
