using Ookly.Core.Interfaces;

namespace Ookly.Core.Entities.AdEntity;

public interface IAdRepository : IRepository<Ad>
{
    Task<List<Ad>> SearchAsync(Dictionary<string, string> filters);
}
