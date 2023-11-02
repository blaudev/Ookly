using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ookly.Core.Entities.CategoryEntity;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);
    }
}
