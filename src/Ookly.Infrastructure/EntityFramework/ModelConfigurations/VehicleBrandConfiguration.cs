using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class VehicleBrandConfiguration : IEntityTypeConfiguration<VehicleBrand>
{
    public void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);
    }
}

