using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.Entities;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class CategoryFilterConfiguration : IEntityTypeConfiguration<CategoryFilter>
{
    public void Configure(EntityTypeBuilder<CategoryFilter> builder)
    {
    }
}
