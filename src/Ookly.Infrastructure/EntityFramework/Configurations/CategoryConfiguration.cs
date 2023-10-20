using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.CategoryAggregate;

namespace Ookly.Infrastructure.EntityFramework.Configurations;

public class ContributorConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}
