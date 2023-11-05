using Microsoft.EntityFrameworkCore;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryRepository(ApplicationContext context) : ApplicationNamedRepository<Country>(context), ICountryRepository
{
    public async Task<List<Country>> GetCountryStatsAsync()
    {
        return await Set
            .Include(i => i.CountryCategories.OrderBy(o => o.Order))
            .OrderBy(o => o.Id)
            .ToListAsync();
    }

    public async Task<Country> GetCountryWithCountryCategoriesAndFiltersAsync(int countryId)
    {
        return await Set
            .Include(i => i.CountryCategories.OrderBy(o => o.Order))
            .Where(i => i.Id == countryId)
            .FirstAsync();
    }
}
