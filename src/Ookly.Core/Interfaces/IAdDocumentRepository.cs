using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface IAdDocumentRepository
{
    Task<bool> AddAsync(Ad adDocument);
    Task<List<Ad>> SearchAsync(List<Filter> filters);
    Task<bool> DeleteAdIndexAsync();
    Task<bool> CreateIndexAsync();
}
