using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ookly.Core.Entities.CountryEntity;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class FilterConfiguration : IEntityTypeConfiguration<CategoryFilter>
{
    public void Configure(EntityTypeBuilder<CategoryFilter> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(60);
    }
}

