using Ookly.Core.Entities.FilterEntity;
using Ookly.Core.Services.SearchService.Models;

namespace Ookly.Core.Services.AdSearchService;

public interface IAdSearchService
{
    Task<SearchResponse> SearchAsync(List<Filter> filters);
}
