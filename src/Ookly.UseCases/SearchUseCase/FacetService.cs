using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.UseCases.SearchUseCase;

public class FacetService(IVehicleBrandRepository vehicleBrandRepository) : IFacetService
{
    public async Task<List<Facet>> VehicleFacetsAsync(SearchUseCaseRequest request)
    {
        List<Facet> facets = [
            await VehicleBrandFacetAsync(),
            await VehicleModelFacetAsync(request.Filters.GetValueOrDefault("VehicleBrand")),
            VehicleYears(),
            VehicleMileage(),
            VehicleFuelTypes(),
            VehicleColors(),
        ];

        return facets;
    }

    public async Task<Facet> VehicleBrandFacetAsync()
    {
        var brands = await vehicleBrandRepository.ListAsync();
        var items = brands.OrderBy(o => o.Id).Select(brand => new FacetItem(brand.Id, brand.Id)).ToList();
        return new("Marca", "VehicleBrand", items);
    }

    public async Task<Facet> VehicleModelFacetAsync(string? vehicleBrand)
    {
        if (string.IsNullOrEmpty(vehicleBrand))
        {
            return new("Modelo", "VehicleModel", []);
        }

        var brand = (await vehicleBrandRepository.WithModelsAsync(vehicleBrand));
        var items = brand.VehicleModels.Select(i => new FacetItem(i.Id, i.Id)).ToList();
        return new("Modelo", "VehicleModel", items);
    }

    public Facet VehicleYears()
    {
        List<FacetItem> items = Enumerable
            .Range(DateTime.Now.Year - 50, 50)
            .Reverse()
            .Select(x => new FacetItem(x.ToString(), x.ToString()))
            .ToList();

        return new("Año", "VehicleYear", items);
    }

    public Facet VehicleMileage()
    {
        List<FacetItem> items = Enumerable.Empty<int>()
            .Concat(Enumerable.Range(1, 2).Select(n => n * 2500))
            .Concat(Enumerable.Range(0, 7).Select(n => 10000 + n * 5000))
            .Concat(Enumerable.Range(0, 6).Select(n => 50000 + n * 10000))
            .Concat(Enumerable.Range(0, 6).Select(n => 100000 + n * 20000))
            .Select(x => new FacetItem($"{x} kms", x.ToString()))
            .ToList();

        return new("Kilometraje", "VehicleMileage", items);
    }

    public Facet VehicleFuelTypes()
    {
        List<FacetItem> items = [
            new FacetItem("Diesel", "Diesel"),
            new FacetItem("Gasolina", "Gasolina")
        ];

        return new("Combustible", "VehicleFuelType", items);
    }

    public Facet VehicleColors()
    {
        List<FacetItem> items = [
            new FacetItem("Azul", "Azul"),
            new FacetItem("Blanco", "Blanco"),
            new FacetItem("Negro", "Negro"),
            new FacetItem("Rojo", "Rojo")
        ];

        return new("Color", "VehicleColor", items);
    }
}
