using Microsoft.EntityFrameworkCore;

using Ookly.Core.AdAggregate;
using Ookly.Core.CountryAggregate;
using Ookly.Core.VehicleBrandAggregate;

using System.Reflection;

namespace Ookly.Infrastructure.EntityFramework;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    // EntityFramework required constructor
    public ApplicationContext() : this(default!) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public virtual DbSet<Ad> Ads => Set<Ad>();
    public virtual DbSet<Category> Categories => Set<Category>();
    public virtual DbSet<Country> Countries => Set<Country>();
    public virtual DbSet<VehicleBrand> VehicleBrands => Set<VehicleBrand>();
    public virtual DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();

    private static Category _vehiclesCategory = new(Guid.NewGuid(), "Vehicles");
    private static Category _realEstateCategory = new(Guid.NewGuid(), "Real Estate");
    private static Country _chile = new(Guid.NewGuid(), "Chile");

    public void SeedTestData()
    {
        SeedCategories();
        SeedCountries();
    }

    private void SeedCategories()
    {
        if (Categories.Any())
        {
            return;
        }

        Categories.Add(_vehiclesCategory);
        Categories.Add(_realEstateCategory);

        SaveChanges();
    }

    private void SeedCountries()
    {
        if (Countries.Any())
        {
            return;
        }

        _chile.AddCategories([_vehiclesCategory, _realEstateCategory]);

        Countries.Add(_chile);

        SaveChanges();
    }
}
