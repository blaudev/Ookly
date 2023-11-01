using Microsoft.EntityFrameworkCore;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryRepository(ApplicationContext context) : Repository<Country>(context), ICountryRepository
{
    public async Task<List<Country>> GetCountryStatsAsync()
    {
        return await context.Countries
            .Include(i => i.Categories.OrderBy(o => o.Id))
            .OrderBy(o => o.Id)
            .ToListAsync();
    }

    public async Task<Country> GetCountryWithCategoryAndFiltersAsync(string countryId)
    {
        return await context.Countries
            .Include(i => i.Categories.OrderBy(o => o.Id))
                .ThenInclude(i => i.Filters.OrderBy(o => o.Id))
            .Where(i => i.Id == countryId)
            .FirstAsync();
    }
}
