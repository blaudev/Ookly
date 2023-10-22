using Ookly.Core.CountryAggregate;
using Ookly.Core.VehicleBrandAggregate;
using Ookly.Web.ViewModels;

namespace Ookly.Web.Services;

public class SeedTestDataService(
    ICountryRepository countryRepository,
    IVehicleBrandRepository vehicleBrandRepository)
{
    private static readonly Category _vehiclesCategory = new(Guid.NewGuid(), "Vehicles");
    private static readonly Category _realEstateCategory = new(Guid.NewGuid(), "Real Estate");
    private static readonly Country _chile = new(Guid.NewGuid(), "Chile");
    private static readonly Country _spain = new(Guid.NewGuid(), "España");
    private static readonly VehicleModel _mercedesBenzC200Model = new(Guid.NewGuid(), "C 200");
    private static readonly VehicleBrand _mercedesBenz = new(Guid.NewGuid(), "Mercedes Benz");

    public async Task SeedAsync()
    {
        await SeedCountriesAsync();
        await SeedVehicleBrandsAsync();
    }

    private async Task SeedCountriesAsync()
    {
        if (await countryRepository.AnyAsync())
        {
            return;
        }

        _chile.AddCategories([_vehiclesCategory]);
        _spain.AddCategories([_vehiclesCategory, _realEstateCategory]);

        await countryRepository.AddAsync([_chile, _spain]);
    }

    private async Task SeedVehicleBrandsAsync()
    {
        if (await vehicleBrandRepository.AnyAsync())
        {
            return;
        }

        _mercedesBenz.AddModel(_mercedesBenzC200Model);
        await vehicleBrandRepository.AddAsync(_mercedesBenz);
    }
}
