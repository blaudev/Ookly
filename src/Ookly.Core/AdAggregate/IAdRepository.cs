using Ookly.Core.Interfaces;

namespace Ookly.Core.AdAggregate;

public interface IAdRepository : IRepository<Ad>
{
    Task<List<Ad>> SearchAsync(Dictionary<string, string> filters);
}
