using Blau.Exceptions;
using Blau.UseCases;

using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseHandler(IVehicleBrandRepository vehicleBrandRepository) : IUseCaseHandler<SearchUseCaseRequest, SearchUseCaseResponse>
{
    public async Task<SearchUseCaseResponse> HandleAsync(SearchUseCaseRequest request)
    {
        request.Validate();

        var facets = request.CategoryName switch
        {
            var name when string.Equals("Vehicles", name, StringComparison.OrdinalIgnoreCase) => await VehicleFacetsAsync(request),
            _ => throw new ValidationException(nameof(request.CategoryName))
        };

        return await Task.FromResult(new SearchUseCaseResponse(request.CountryName, request.CategoryName, request.Filters, facets, 0, []));
    }

    private async Task<List<Facet>> VehicleFacetsAsync(SearchUseCaseRequest request)
    {
        List<Facet> facets = [await VehicleBrandsFacetAsync(request)];

        return facets;
    }

    private async Task<Facet> VehicleBrandsFacetAsync(SearchUseCaseRequest request)
    {
        var vehicleBrand = request.Filters.GetValueOrDefault("VehicleBrand", "");
        var brands = await vehicleBrandRepository.ListAsync();
        var items = brands.OrderBy(o => o.Name).Select(brand => new FacetItem(brand.Name, brand.Name)).ToList();
        return new Facet("Marca", "VehicleBrand", vehicleBrand, items);
    }
}
