using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class AdConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
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
    }
}

