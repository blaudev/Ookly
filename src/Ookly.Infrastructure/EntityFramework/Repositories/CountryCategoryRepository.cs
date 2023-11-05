using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CountryCategoryRepository(ApplicationContext context) : ApplicationRepository<CountryCategory>(context), ICountryCategoryRepository
{
}
