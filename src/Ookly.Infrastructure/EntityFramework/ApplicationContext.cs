using Microsoft.EntityFrameworkCore;

using Ookly.Core.AdAggregate;
using Ookly.Core.CategoryAggregate;

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

    public void SeedTestData()
    {
        if (Categories.Any())
        {
            return;
        }

        var vehiclesCategory = new Category("Vehicles");
        var realEstateCategory = new Category("Real Estate");

        Categories.Add(vehiclesCategory);
        Categories.Add(realEstateCategory);

        SaveChanges();
    }
}
