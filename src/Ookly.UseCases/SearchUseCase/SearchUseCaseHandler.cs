using Blau.UseCases;

using Ookly.Core.Interfaces;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IAdDocumentRepository repository) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        var s = await repository.SearchAsync(request.CountryCategory);

        request.CountryCategory.CategoryFilters.ToDictionary(k => k.FilterId, v => v);

        var response = new SearchUseCaseResponse(request.CountryCategory.Country.Id, request.CountryCategory.CategoryId, request.FilterValues, null, 10, []);
        return await Task.FromResult(response);
    }
}
