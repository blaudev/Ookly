using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.Entities;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(20);
    }
}
