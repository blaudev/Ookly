using Ookly.Core.Interfaces;

namespace Ookly.Core.CountryAggregate;

public interface ICountryRepository : IRepository<Country>
{
    Task<List<Country>> GetCountryStatsAsync();
}
