using Blau.Data;
using Blau.Entities;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class ApplicationNamedRepository<TNamedEntity>(ApplicationContext context)
    : NamedRepository<ApplicationContext, TNamedEntity>(context)
        where TNamedEntity : class, INamedEntity
{
}
