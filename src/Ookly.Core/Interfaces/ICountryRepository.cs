using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface ICountryRepository : IRepository<Country>
{
    Task<List<Country>> GetCountryStatsAsync();
    Task<Country> GetCountryWithCountryCategoriesAndFiltersAsync(string countryId);
}
