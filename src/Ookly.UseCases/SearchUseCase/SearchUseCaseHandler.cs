using Blau.UseCases;

using Ookly.Core.Services.AdSearchService;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IAdSearchService service) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        var filters = request.CountryCategory.CategoryFilters.Select(f => f.Filter).ToList();
        var s = await service.SearchAsync(filters);

        request.CountryCategory.CategoryFilters.ToDictionary(k => k.FilterId, v => v);

        var response = new SearchUseCaseResponse(request.CountryCategory.Country.Id, request.CountryCategory.CategoryId, request.FilterValues, s.Facets, 10, []);
        return response;
    }
}
