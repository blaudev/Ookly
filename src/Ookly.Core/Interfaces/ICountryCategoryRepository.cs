using Blau.Data;

using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface ICountryCategoryRepository : IRepository<CountryCategory>
{
    Task<CountryCategory> FirstByCountryIdAndCategoryIdAsync(int countryId, int categoryId);
}
