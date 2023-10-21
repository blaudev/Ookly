namespace Ookly.Core.Interfaces;

public interface IRepository<T> where T : Entity, IAggregateRoot
{
    Task<bool> AnyAsync();
    Task<T> ByIdAsync(Guid id);
    Task<List<T>> ListAsync();
    Task AddAsync(T entity);
    Task AddAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
