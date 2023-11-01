using Blau.UseCases;

using Ookly.Core.Interfaces;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IAdDocumentRepository repository) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        request.Validate();

        var s = await repository.SearchAsync();

        var response = new SearchUseCaseResponse(request.CountryId, request.CategoryId, request.Filters, null, 10, []);
        return await Task.FromResult(response);
    }
}
