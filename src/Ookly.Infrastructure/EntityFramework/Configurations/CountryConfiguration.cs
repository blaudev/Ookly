using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);

        builder
            .HasMany(p => p.Categories)
            .WithMany(p => p.Countries)
            .UsingEntity("CountryCategory");

        builder
            .HasMany(p => p.Filters)
            .WithMany(p => p.Countries)
            .UsingEntity("CountryFilter");
    }
}

