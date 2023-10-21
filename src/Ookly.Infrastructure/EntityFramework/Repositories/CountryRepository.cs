using Microsoft.EntityFrameworkCore;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryRepository(ApplicationContext context) : ICountryRepository
{
    public async Task<List<Country>> GetCountryStatsAsync()
    {
        return await context.Countries
            .Include(i => i.Categories.OrderBy(o => o.Name))
            .OrderBy(o => o.Name)
            .ToListAsync();
    }
}
