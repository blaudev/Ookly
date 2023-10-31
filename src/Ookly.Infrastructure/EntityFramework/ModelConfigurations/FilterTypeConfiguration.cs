using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class FilterTypeConfiguration : IEntityTypeConfiguration<FilterType>
{
    public void Configure(EntityTypeBuilder<FilterType> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);

        builder.Property(p => p.ValueType)
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsRequired();
    }
}
