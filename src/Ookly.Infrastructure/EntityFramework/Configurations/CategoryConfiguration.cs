using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.Configurations;

public class ContributorConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);
    }
}
