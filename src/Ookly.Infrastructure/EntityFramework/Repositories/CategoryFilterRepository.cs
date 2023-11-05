using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CategoryFilterRepository(ApplicationContext context) : ApplicationRepository<CategoryFilter>(context), ICategoryFilterRepository
{
}
