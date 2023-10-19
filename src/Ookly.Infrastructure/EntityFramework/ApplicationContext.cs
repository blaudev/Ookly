using Microsoft.EntityFrameworkCore;

using Ookly.Core.AdAggregate;

namespace Ookly.Infrastructure.EntityFramework;

public class ApplicationContext : DbContext
{
    public ApplicationContext() { }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) { }

    public virtual DbSet<Ad> Ads => Set<Ad>();
}
