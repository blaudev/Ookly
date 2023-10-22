using Blau.UseCases;

namespace Ookly.UseCases.SearchAd;

public class SearchAdUseCaseHandler : IUseCaseHandler<SearchAdUseCaseRequest, SearchAdUseCaseResponse>
{
    public async Task<SearchAdUseCaseResponse> HandleAsync(SearchAdUseCaseRequest request)
    {
        request.Validate();

        return await Task.FromResult(new SearchAdUseCaseResponse());
    }
}
