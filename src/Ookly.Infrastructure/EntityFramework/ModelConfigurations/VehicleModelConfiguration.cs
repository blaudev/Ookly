using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(20);
    }
}

