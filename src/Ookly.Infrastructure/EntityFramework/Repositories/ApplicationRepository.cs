using Blau.Data;
using Blau.Entities;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public abstract class ApplicationRepository<TEntity>(ApplicationContext context)
    : Repository<ApplicationContext, TEntity>(context)
        where TEntity : class, IEntity
{
}
