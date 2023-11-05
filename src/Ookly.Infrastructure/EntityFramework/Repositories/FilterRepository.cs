using Microsoft.EntityFrameworkCore;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class FilterRepository(ApplicationContext context) : ApplicationRepository<Filter>(context), IFilterRepository
{
    public async Task<List<Filter>> ListByCountryCategoryIdNameAsync(int countryCategoryId, CancellationToken cancellationToken = default)
    {
        return await Set.Where(f => f.CountryCategories.Any(q => q.Id == countryCategoryId)).ToListAsync(cancellationToken);
    }
}
