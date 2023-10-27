using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.AdAggregate;

namespace Ookly.Infrastructure.EntityFramework.Configurations;

public class AdConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.Property(p => p.SourceUrl)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(p => p.Title)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(p => p.PictureUrl)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(p => p.State)
            .HasMaxLength(30);

        builder.Property(p => p.City)
            .HasMaxLength(30);

        builder.Property(p => p.VehicleFuelType)
            .HasMaxLength(10);

        builder.Property(p => p.VehicleColor)
            .HasMaxLength(10);
    }
}

