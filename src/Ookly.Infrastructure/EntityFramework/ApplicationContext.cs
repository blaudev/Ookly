using Blau.Data;

using Microsoft.EntityFrameworkCore;

using Ookly.Core.Entities;
using Ookly.Core.Entities.ListingEntity;

using System.Reflection;

namespace Ookly.Infrastructure.EntityFramework;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DataContext<ApplicationContext>(options)
{
    // EntityFramework required constructor
    public ApplicationContext() : this(default!) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<CountryCategory> CountryCategories => Set<CountryCategory>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<ListingDetail> ListingDetails => Set<ListingDetail>();
}
