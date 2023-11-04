using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.Entities;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class FilterConfiguration : IEntityTypeConfiguration<Filter>
{
    public void Configure(EntityTypeBuilder<Filter> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(20);

        builder
            .Property(e => e.Type)
            .HasConversion(
                v => v.ToString(),
                v => (FilterType)Enum.Parse(typeof(FilterType), v));

        builder
            .Property(e => e.Sort)
            .HasConversion(
                v => v.ToString(),
                v => (FilterSort)Enum.Parse(typeof(FilterSort), v));
    }
}

