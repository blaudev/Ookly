using Blau.Exceptions;
using Blau.UseCases;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IFacetService facetService) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        request.Validate();

        var facets = request.CategoryName switch
        {
            "Vehicles" => await facetService.VehicleFacetsAsync(request),
            _ => throw new ValidationException(nameof(request.CategoryName))
        };

        var response = new SearchUseCaseResponse(request.CountryName, request.CategoryName, request.Filters, facets, 0, []);
        return await Task.FromResult(response);
    }
}
