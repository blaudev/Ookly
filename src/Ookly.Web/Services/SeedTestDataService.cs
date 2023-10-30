using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Ookly.Core.AdAggregate;
using Ookly.Core.AdDocumentAggregate;
using Ookly.Core.CountryAggregate;
using Ookly.Core.VehicleBrandAggregate;
using Ookly.Infrastructure.EntityFramework;
using Ookly.Web.Configuration;

using System.Text;

namespace Ookly.Web.Services;

public class SeedTestDataService(
    ApplicationContext context,
    IOptions<DataOptions> dataOptions,
    ICountryRepository countryRepository,
    IVehicleBrandRepository vehicleBrandRepository,
    IAdRepository adRepository,
    IAdDocumentRepository adDocumentRepository)
{
    private readonly DataOptions options = dataOptions.Value;

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
        if (!options.Seed)
        {
            return;
        }

        if (options.Truncate)
        {
            await TruncateAsync();

            await DeleteIndicesAsync();
            await CreateIndicesAsync();
        }

        await SeedCountriesAsync();
        await SeedVehicleBrandsAsync();
        await SeedAdsAsync();
    }

    private async Task TruncateAsync()
    {
        var statements = context.Model
            .GetEntityTypes()
            .Select(entity => $"TRUNCATE TABLE public.\"{entity.GetTableName()}\" CONTINUE IDENTITY CASCADE;")
            .ToList();

        var sql = string.Join("\n", statements);
        var sb = new StringBuilder(sql);

        await context.Database.ExecuteSqlRawAsync(sql);
    }

    private async Task DeleteIndicesAsync()
    {
        await adDocumentRepository.DeleteAdIndexAsync();
    }

    private async Task CreateIndicesAsync()
    {
        await adDocumentRepository.CreateIndexAsync();
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

        var adDocument = new AdDocument(
            ad.Id,
            ad.CountryId,
            ad.CategoryId,
            ad.PictureUrl,
            ad.Title,
            ad.Description,
            ad.Price,
            ad.Properties.ToDictionary(x => x.FilterType.Id, x =>
                (object)(x switch
                {
                    { TextValue: string value } => value,
                    { NumericValue: decimal value } => value,
                    _ => throw new Exception()
                }))
        );

        await adDocumentRepository.AddAsync(adDocument);
    }
}
