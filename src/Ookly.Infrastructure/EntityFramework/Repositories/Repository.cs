using Blau.Entities;

using Microsoft.EntityFrameworkCore;

using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class Repository<T>(ApplicationContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly ApplicationContext context = context;

    public async Task<bool> AnyAsync()
    {
        return await context.Set<T>().AnyAsync();
    }
    public async Task<T?> ByIdAsync(object id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> ListAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(IEnumerable<T> entities)
    {
        await context.Set<T>().AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}
