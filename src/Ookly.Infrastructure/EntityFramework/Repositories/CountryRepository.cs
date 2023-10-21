using Microsoft.EntityFrameworkCore;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationContext _context;

    public CountryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetCountryStatsAsync()
    {
        return await _context.Countries
            .Include(i => i.Categories)
            .ToListAsync();
    }
}
