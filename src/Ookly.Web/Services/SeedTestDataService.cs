using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Ookly.Core.Entities.AdEntity;
using Ookly.Core.Entities.CategoryEntity;
using Ookly.Core.Entities.CountryEntity;
using Ookly.Core.Entities.FilterEntity;
using Ookly.Core.Services.AdElasticIndexService;
using Ookly.Infrastructure.EntityFramework;
using Ookly.Infrastructure.Options;

using System.Text;

namespace Ookly.Web.Services;

public class SeedTestDataService(
    ApplicationContext context,
    IOptions<DatabaseOptions> dataOptions,
    ICountryRepository countryRepository,
    IAdRepository adRepository,
    IElasticAdIndexService elasticAdIndexService
)
{
    private readonly DatabaseOptions options = dataOptions.Value;

    private static readonly Country _chile = new("chile");
    private static readonly Country _spain = new("spain");

    private static readonly Category _vehiclesCategory = new("vehicles");
    private static readonly Category _realEstateCategory = new("real-estate");

    private static readonly CountryCategory _chileVehiclesCategory = new(_chile, _vehiclesCategory, 1);
    private static readonly CountryCategory _chileRealEstateCategory = new(_chile, _realEstateCategory, 2);

    private static readonly CountryCategory _spainVehiclesCategory = new(_spain, _vehiclesCategory, 1);

    private static readonly Filter _brandFilter = new("brand", FilterType.Text, SortType.FilterIdAsc, 1, _vehiclesCategory, null);
    private static readonly Filter _modelFilter = new("model", FilterType.Text, SortType.FilterIdAsc, 2, _vehiclesCategory, _brandFilter);
    private static readonly Filter _yearFilter = new("year", FilterType.Numeric, SortType.FilterIdDesc, 3, _vehiclesCategory, null);

    private static readonly CategoryFilter _chileBrandFilter = new(_chileVehiclesCategory, _brandFilter);
    private static readonly CategoryFilter _chileModelFilter = new(_chileVehiclesCategory, _modelFilter);
    private static readonly CategoryFilter _chileYearFilter = new(_chileVehiclesCategory, _yearFilter);

    private static readonly CategoryFilter _spainBrandFilter = new(_spainVehiclesCategory, _brandFilter);
    private static readonly CategoryFilter _spainModelFilter = new(_spainVehiclesCategory, _modelFilter);
    private static readonly CategoryFilter _spainYearFilter = new(_spainVehiclesCategory, _yearFilter);

    private static readonly Ad mercedesA180 = new(AdStatus.Active, "", _chile, _chileVehiclesCategory, "", "Mercedes Benz A 180 del 2021", 5000000);
    private static readonly Ad mercedesC200 = new(AdStatus.Active, "", _chile, _chileVehiclesCategory, "", "Mercedes Benz C 200 del 2023", 10000000);

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
        await elasticAdIndexService.DeleteIndexAsync();
    }

    private async Task CreateIndicesAsync()
    {
        await elasticAdIndexService.CreateIndexAsync();
    }

    private async Task SeedCountriesAsync()
    {
        if (await countryRepository.AnyAsync())
        {
            return;
        }

        _chileVehiclesCategory.AddCategoryFilter(_chileBrandFilter);
        _chileVehiclesCategory.AddCategoryFilter(_chileModelFilter);
        _chileVehiclesCategory.AddCategoryFilter(_chileYearFilter);

        _chile.AddCountryCategory(_chileVehiclesCategory);
        _chile.AddCountryCategory(_chileRealEstateCategory);

        _spainVehiclesCategory.AddCategoryFilter(_spainBrandFilter);
        _spainVehiclesCategory.AddCategoryFilter(_spainModelFilter);
        _spainVehiclesCategory.AddCategoryFilter(_spainYearFilter);

        _spain.AddCountryCategory(_spainVehiclesCategory);

        await countryRepository.AddAsync([_chile, _spain]);
    }

    private async Task SeedAdsAsync()
    {
        if (await adRepository.AnyAsync())
        {
            return;
        }

        mercedesA180.AddProperties(
            [
                new AdProperty(mercedesA180, _brandFilter, "Mercedes Benz"),
                new AdProperty(mercedesA180, _modelFilter, "A 180"),
                new AdProperty(mercedesA180, _yearFilter, 2021)
            ]
        );

        await adRepository.AddAsync(mercedesA180);
        await elasticAdIndexService.AddAdAsync(mercedesA180);

        mercedesC200.AddProperties(
            [
                new AdProperty(mercedesC200, _brandFilter, "Mercedes Benz"),
                new AdProperty(mercedesC200, _modelFilter, "C 200"),
                new AdProperty(mercedesC200, _yearFilter, 2023)
            ]
        );

        await adRepository.AddAsync(mercedesC200);
        await elasticAdIndexService.AddAdAsync(mercedesC200);
    }
}
