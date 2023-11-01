using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ookly.Core.Entities;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<CountryCategory>
{
    public void Configure(EntityTypeBuilder<CountryCategory> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(40);
    }
}
