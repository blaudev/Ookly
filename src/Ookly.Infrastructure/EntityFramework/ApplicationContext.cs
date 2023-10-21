using Microsoft.EntityFrameworkCore;

using Ookly.Core.AdAggregate;
using Ookly.Core.CategoryAggregate;
using Ookly.Core.CountryAggregate;

using System.Reflection;

namespace Ookly.Infrastructure.EntityFramework;

public class ApplicationContext : DbContext
{
    public ApplicationContext() { }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public virtual DbSet<Ad> Ads => Set<Ad>();
    public virtual DbSet<Category> Categories => Set<Category>();
    public virtual DbSet<Country> Countries => Set<Country>();

    private Category _vehiclesCategory = new(Guid.NewGuid(), "Vehicles");
    private Category _realEstateCategory = new(Guid.NewGuid(), "Real Estate");
    private Country _chileCountry = new(Guid.NewGuid(), "Chile");

    public void SeedTestData()
    {
        SeedCategories();
        SeedCountries();
    }

    public void SeedCategories()
    {
        if (Categories.Any())
        {
            return;
        }

        Categories.Add(_vehiclesCategory);
        Categories.Add(_realEstateCategory);

        SaveChanges();
    }

    public void SeedCountries()
    {
        if (Countries.Any())
        {
            return;
        }

        _chileCountry.AddCategories([_vehiclesCategory, _realEstateCategory]);

        Countries.Add(_chileCountry);

        SaveChanges();
    }
}
