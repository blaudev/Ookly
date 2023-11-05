using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class CategoryRepository(ApplicationContext context) : ApplicationNamedRepository<Category>(context), ICategoryRepository
{
}
