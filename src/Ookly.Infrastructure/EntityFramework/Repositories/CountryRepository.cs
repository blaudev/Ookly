using Microsoft.EntityFrameworkCore;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryRepository(ApplicationContext context) : ApplicationNamedRepository<Country>(context), ICountryRepository
{
    public async Task<List<Country>> GetCountryStatsAsync()
    {
        return await Context.Countries
            .Include(i => i.CountryCategories.OrderBy(o => o.Order))
            .OrderBy(o => o.Id)
            .ToListAsync();
    }

    public async Task<Country> GetCountryWithCountryCategoriesAndFiltersAsync(int countryId)
    {
        return await Context.Countries
            .Include(i => i.CountryCategories.OrderBy(o => o.Order))
                .ThenInclude(i => i.CategoryFilters.OrderBy(o => o.Filter.Order))
                    .ThenInclude(i => i.Filter)
            .Where(i => i.Id == countryId)
            .FirstAsync();
    }
}
