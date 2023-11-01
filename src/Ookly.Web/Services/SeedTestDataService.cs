using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;
using Ookly.Infrastructure.EntityFramework;
using Ookly.Infrastructure.Options;

using System.Text;

namespace Ookly.Web.Services;

public class SeedTestDataService(
    ApplicationContext context,
    IOptions<DatabaseOptions> dataOptions,
    ICountryRepository countryRepository,
    IAdRepository adRepository,
    IAdDocumentRepository adDocumentRepository)
{
    private readonly DatabaseOptions options = dataOptions.Value;

    private static readonly Country _chile = new("chile");
    private static readonly Country _spain = new("spain");

    private static readonly Category _vehiclesCategory = new("vehicles");
    private static readonly Category _realEstateCategory = new("real-estate");

    private static readonly CountryCategory _chileVehiclesCategory = new(_chile, _vehiclesCategory);
    private static readonly CountryCategory _chileRealEstateCategory = new(_chile, _realEstateCategory);

    private static readonly CountryCategory _spainVehiclesCategory = new(_spain, _vehiclesCategory);

    private static readonly Filter _brandFilter = new("brand", FilterType.Text);
    private static readonly Filter _modelFilter = new("model", FilterType.Text);
    private static readonly Filter _yearFilter = new("year", FilterType.Numeric);

    private static readonly CategoryFilter _chileBrandFilter = new(_chileVehiclesCategory, _brandFilter);
    private static readonly CategoryFilter _chileModelFilter = new(_chileVehiclesCategory, _modelFilter);
    private static readonly CategoryFilter _chileYearFilter = new(_chileVehiclesCategory, _yearFilter);

    private static readonly CategoryFilter _spainBrandFilter = new(_spainVehiclesCategory, _brandFilter);
    private static readonly CategoryFilter _spainModelFilter = new(_spainVehiclesCategory, _modelFilter);
    private static readonly CategoryFilter _spainYearFilter = new(_spainVehiclesCategory, _yearFilter);

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

        _chileVehiclesCategory.AddFilter(_chileBrandFilter);
        _chileVehiclesCategory.AddFilter(_chileModelFilter);
        _chileVehiclesCategory.AddFilter(_chileYearFilter);

        _chile.AddCategory(_chileVehiclesCategory);
        _chile.AddCategory(_chileRealEstateCategory);

        _spainVehiclesCategory.AddFilter(_spainBrandFilter);
        _spainVehiclesCategory.AddFilter(_spainModelFilter);
        _spainVehiclesCategory.AddFilter(_spainYearFilter);

        _spain.AddCategory(_spainVehiclesCategory);

        await countryRepository.AddAsync([_chile, _spain]);
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
                new AdProperty(ad, _brandFilter, "Mercedes Benz"),
                new AdProperty(ad, _modelFilter, "C 200"),
                new AdProperty(ad, _yearFilter, 2023)
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
            ad.Properties.Select(x =>
            {
                var convertedValue = (object)(x switch
                {
                    { TextValue: string value } => value,
                    { NumericValue: decimal value } => value,
                    _ => throw new Exception()
                });

                return new Property(x.FilterId, convertedValue);

            }).ToList()
        );

        await adDocumentRepository.AddAsync(adDocument);
    }
}
