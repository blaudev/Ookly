using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.Configurations;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
{
    public void Configure(EntityTypeBuilder<CategoryType> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);
    }
}
