using Microsoft.EntityFrameworkCore;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryCategoryRepository(ApplicationContext context)
    : ApplicationRepository<CountryCategory>(context), ICountryCategoryRepository
{
    public async Task<CountryCategory> FirstByCountryIdAndCategoryIdAsync(int countryId, int categoryId)
    {
        return await Set.FirstAsync(q => q.CountryId == countryId && q.CategoryId == categoryId);
    }
}
