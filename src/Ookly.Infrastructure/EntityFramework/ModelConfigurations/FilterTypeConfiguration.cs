using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ookly.Core.Entities.FilterEntity;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class FilterTypeConfiguration : IEntityTypeConfiguration<Filter>
{
    public void Configure(EntityTypeBuilder<Filter> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);

        builder.Property(p => p.ValueType)
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsRequired();
    }
}
