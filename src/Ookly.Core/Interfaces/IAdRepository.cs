using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface IAdRepository : IRepository<Ad>
{
    Task<List<Ad>> SearchAsync(Dictionary<string, string> filters);
}
