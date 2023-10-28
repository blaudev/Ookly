﻿
namespace Ookly.UseCases.SearchUseCase
{
    public interface IFacetService
    {
        Facet VehicleColors();
        Task<Facet> VehicleBrandFacetAsync();
        Task<List<Facet>> VehicleFacetsAsync(SearchUseCaseRequest request);
        Facet VehicleFuelTypes();
        Facet VehicleMileage();
        Task<Facet> VehicleModelFacetAsync(string vehicleBrand);
        Facet VehicleYears();
    }
}