namespace Ookly.Core.AdAggregate;

public interface IAdRepository
{
    Task<List<Ad>> SearchAsync(Dictionary<string, string> filters);
}
