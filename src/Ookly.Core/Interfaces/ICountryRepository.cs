using Blau.Data;

using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface ICountryRepository : INamedRepository<Country>
{
    Task<List<Country>> GetCountryStatsAsync();
    Task<Country> GetCountryWithCountryCategoriesAndFiltersAsync(int countryId);
}
