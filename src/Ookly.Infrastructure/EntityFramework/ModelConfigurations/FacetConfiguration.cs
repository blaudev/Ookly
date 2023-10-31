using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.CountryAggregate;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class FacetConfiguration : IEntityTypeConfiguration<Facet>
{
    public void Configure(EntityTypeBuilder<Facet> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(256);
    }
}
