using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CategoryRepository(ApplicationContext context) : ApplicationRepository<Category>(context), ICategoryRepository
{
}
