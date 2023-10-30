using Blau.Exceptions;
using Blau.UseCases;

using Ookly.Core.AdDocumentAggregate;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IFacetService facetService, IAdDocumentRepository repository) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        request.Validate();

        var facets = request.CategoryId switch
        {
            "vehicles" => await facetService.VehicleFacetsAsync(request),
            _ => throw new ValidationException(nameof(request.CategoryId))
        };

        var s = await repository.SearchAsync();

        var response = new SearchUseCaseResponse(request.CountryId, request.CategoryId, request.Filters, facets, 10, []);
        return await Task.FromResult(response);
    }
}
