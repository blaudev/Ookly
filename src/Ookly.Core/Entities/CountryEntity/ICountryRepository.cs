using Ookly.Core.Interfaces;

namespace Ookly.Core.Entities.CountryEntity;

public interface ICountryRepository : IRepository<Country>
{
    Task<List<Country>> GetCountryStatsAsync();
    Task<Country> GetCountryWithCountryCategoriesAndFiltersAsync(string countryId);
}
