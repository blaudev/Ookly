using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface IAdDocumentRepository
{
    Task<bool> AddAsync(AdDocument adDocument);
    Task<List<Ad>> SearchAsync();
    Task<bool> DeleteAdIndexAsync();
    Task<bool> CreateIndexAsync();
}
