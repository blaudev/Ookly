using Blau.Exceptions;
using Blau.UseCases;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IFacetService facetService) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        request.Validate();

        var facets = request.CategoryId switch
        {
            "Vehicles" => await facetService.VehicleFacetsAsync(request),
            _ => throw new ValidationException(nameof(request.CategoryId))
        };

        var response = new SearchUseCaseResponse(request.CountryId, request.CategoryId, request.Filters, facets, 10, []);
        return await Task.FromResult(response);
    }
}
