using Blau.Data;

using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface IFilterRepository : IRepository<Filter>
{
    public Task<List<Filter>> ListByCountryCategoryIdNameAsync(int ciuntryCategoryId, CancellationToken cancellationToken = default);
}
