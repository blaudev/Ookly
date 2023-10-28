using Ookly.Core.AdAggregate;
using Ookly.Core.CountryAggregate;
using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.Web.Services;

public class SeedTestDataService(
    ICountryRepository countryRepository,
    IVehicleBrandRepository vehicleBrandRepository,
    IAdRepository adRepository)
{
    private static readonly Country _chile = new("chile");
    private static readonly Country _spain = new("spain");

    private static readonly CategoryType _vehiclesCategoryType = new("vehicles");
    private static readonly CategoryType _realEstateCategoryType = new("real-estate");

    private static readonly Category _chileVehiclesCategory = new(_chile, _vehiclesCategoryType);

    private static readonly FilterType _vehicleBrandFilterType = new("brand", FilterTypeValueType.Text);
    private static readonly FilterType _vehicleModelFilterType = new("model", FilterTypeValueType.Text);
    private static readonly FilterType _vehicleYearFilterType = new("year", FilterTypeValueType.Numeric);

    private static readonly Filter _chileVehicleBrandFilter = new(_chileVehiclesCategory, _vehicleBrandFilterType);
    private static readonly Filter _chileYearFilter = new(_chileVehiclesCategory, _vehicleYearFilterType);

    private static readonly VehicleModel _mercedesBenzC200Model = new("C 200");
    private static readonly VehicleBrand _mercedesBenz = new("Mercedes Benz");

    public async Task SeedAsync()
    {
        await SeedCountriesAsync();
        await SeedVehicleBrandsAsync();
        await SeedAdsAsync();
    }

    private async Task SeedCountriesAsync()
    {
        if (await countryRepository.AnyAsync())
        {
            return;
        }

        _chileYearFilter.AddFacets(Enumerable
            .Range(DateTime.Now.Year - 50, 50)
            .Reverse()
            .Select(x => new Facet(_chileYearFilter, x.ToString(), x.ToString()))
            .ToList());

        _chileVehiclesCategory.AddFilter(_chileYearFilter);

        _chileVehiclesCategory.AddFilter(_chileVehicleBrandFilter);

        _chile.AddCategory(_chileVehiclesCategory);


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

    private async Task SeedAdsAsync()
    {
        if (await adRepository.AnyAsync())
        {
            return;
        }

        var ad = new Ad
        (
            AdStatus.Active,
            "",
            _chile,
            _chileVehiclesCategory,
            "",
            "Mercedes Benz C 200 del 2023",
            10000000
        );

        ad.AddProperties(
            [
                new AdProperty(ad, _vehicleBrandFilterType, _mercedesBenz.Id),
                new AdProperty(ad, _vehicleModelFilterType, _mercedesBenzC200Model.Id),
                new AdProperty(ad, _vehicleYearFilterType, 2023)
            ]
        );

        await adRepository.AddAsync(ad);
    }
}
