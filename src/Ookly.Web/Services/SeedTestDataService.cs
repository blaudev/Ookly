using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Ookly.Core.Entities;
using Ookly.Core.Entities.ListingEntity;
using Ookly.Core.Interfaces;
using Ookly.Core.Services.AdElasticIndexService;
using Ookly.Infrastructure.EntityFramework;
using Ookly.Infrastructure.Options;

using System.Text;

namespace Ookly.Web.Services;

public class SeedTestDataService(
    ApplicationContext context,
    IOptions<DatabaseOptions> dataOptions,
    ICountryRepository countryRepository,
    ICategoryRepository categoryRepository,
    ICountryCategoryRepository countryCategoryRepository,
    IFilterRepository filterRepository,
    ICategoryFilterRepository categoryFilterRepository,
    IElasticAdIndexService elasticAdIndexService
)
{
    private readonly DatabaseOptions options = dataOptions.Value;

    private static Country _chile = new();
    private static Country _spain = new();

    private static Category _vehiclesCategory = new();
    private static Category _realEstateCategory = new();

    private static CountryCategory _chileVehiclesCountryCategory = new();
    private static CountryCategory _chileRealEstateCountryCategory = new();

    private static CountryCategory _spainVehiclesCountryCategory = new();

    private static Filter _brandFilter = new();
    private static Filter _modelFilter = new();
    private static Filter _yearFilter = new();

    private static CategoryFilter _chileBrandCategoryFilter = new();
    private static CategoryFilter _chileModelCategoryFilter = new();
    private static CategoryFilter _chileYearCategoryFilter = new();

    private static CategoryFilter _spainBrandCategoryFilter = new();
    private static CategoryFilter _spainModelCategoryFilter = new();
    private static CategoryFilter _spainYearCategoryFilter = new();

    private static Listing mercedesA180 = new(ListingStatus.Active, "", _chile, _chileVehiclesCountryCategory, "", "Mercedes Benz A 180 del 2021", 5000000);
    private static Listing mercedesC200 = new(ListingStatus.Active, "", _chile, _chileVehiclesCountryCategory, "", "Mercedes Benz C 200 del 2023", 10000000);

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
        await SeedCategoriesAsync();
        await SeedCountryCategoriesAsync();
        await SeedFiltersAsync();
        //await SeedAdsAsync();
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

        _chile = new() { Name = "Chile" };
        _spain = new() { Name = "España" };

        await countryRepository.AddAsync([_chile, _spain]);
    }

    private async Task SeedCategoriesAsync()
    {
        if (await categoryRepository.AnyAsync())
        {
            return;
        }

        _vehiclesCategory = new() { Name = "Vehicles" };
        _realEstateCategory = new() { Name = "Real Estate" };

        await categoryRepository.AddAsync([_vehiclesCategory, _realEstateCategory]);
    }

    private async Task SeedCountryCategoriesAsync()
    {
        if (await countryCategoryRepository.AnyAsync())
        {
            return;
        }


        _chileVehiclesCountryCategory = new() { CountryId = _chile.Id, CategoryId = _vehiclesCategory.Id, Order = 1 };
        _chileRealEstateCountryCategory = new() { CountryId = _chile.Id, CategoryId = _realEstateCategory.Id, Order = 2 };
        _spainVehiclesCountryCategory = new() { CountryId = _spain.Id, CategoryId = _vehiclesCategory.Id, Order = 1 };

        await countryCategoryRepository.AddAsync(
            [
                _chileVehiclesCountryCategory,
                _chileRealEstateCountryCategory,
                _spainVehiclesCountryCategory
            ]
        );
    }

    private async Task SeedFiltersAsync()
    {
        if (await filterRepository.AnyAsync())
        {
            return;
        }

        _brandFilter = new() { Name = "brand", CategoryId = _vehiclesCategory.Id, Type = FilterType.Text, Sort = FilterSort.FilterNameAsc, Order = 1 };
        _yearFilter = new() { Name = "year", CategoryId = _vehiclesCategory.Id, Type = FilterType.Numeric, Sort = FilterSort.FilterNameDesc, Order = 3 };

        await filterRepository.AddAsync([_brandFilter, _yearFilter]);

        _modelFilter = new() { Name = "model", CategoryId = _vehiclesCategory.Id, Type = FilterType.Text, Sort = FilterSort.FilterNameAsc, Order = 2, ParentId = _brandFilter.Id };

        await filterRepository.AddAsync(_modelFilter);
    }

    private async Task SeedCategoryFiltersAsync()
    {
        if (await categoryFilterRepository.AnyAsync())
        {
            return;
        }

        _chileBrandCategoryFilter = new() { CountryCategoryId = _chileVehiclesCountryCategory.Id, FilterId = _brandFilter.Id };
        _chileModelCategoryFilter = new() { CountryCategoryId = _chileVehiclesCountryCategory.Id, FilterId = _modelFilter.Id };
        _chileYearCategoryFilter = new() { CountryCategoryId = _chileVehiclesCountryCategory.Id, FilterId = _yearFilter.Id };

        _spainBrandCategoryFilter = new() { CountryCategoryId = _spainVehiclesCountryCategory.Id, FilterId = _brandFilter.Id };
        _spainModelCategoryFilter = new() { CountryCategoryId = _spainVehiclesCountryCategory.Id, FilterId = _modelFilter.Id };
        _spainYearCategoryFilter = new() { CountryCategoryId = _spainVehiclesCountryCategory.Id, FilterId = _yearFilter.Id };


        await categoryFilterRepository.AddAsync(
            [
                _chileBrandCategoryFilter,
                _chileModelCategoryFilter,
                _chileYearCategoryFilter,
                _spainBrandCategoryFilter,
                _spainModelCategoryFilter,
                _spainYearCategoryFilter
            ]
        );
    }

    //private async Task SeedAdsAsync()
    //{
    //    if (await adRepository.AnyAsync())
    //    {
    //        return;
    //    }

    //    mercedesA180.AddProperties(
    //        [
    //            new ListingDetail(mercedesA180, _brandFilter, "Mercedes Benz"),
    //            new ListingDetail(mercedesA180, _modelFilter, "A 180"),
    //            new ListingDetail(mercedesA180, _yearFilter, 2021)
    //        ]
    //    );

    //    await adRepository.AddAsync(mercedesA180);
    //    await elasticAdIndexService.AddAdAsync(mercedesA180);

    //    mercedesC200.AddProperties(
    //        [
    //            new ListingDetail(mercedesC200, _brandFilter, "Mercedes Benz"),
    //            new ListingDetail(mercedesC200, _modelFilter, "C 200"),
    //            new ListingDetail(mercedesC200, _yearFilter, 2023)
    //        ]
    //    );

    //    await adRepository.AddAsync(mercedesC200);
    //    await elasticAdIndexService.AddAdAsync(mercedesC200);
    //}
}
