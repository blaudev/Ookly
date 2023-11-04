using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ookly.Core.Entities;

namespace Ookly.Infrastructure.EntityFramework.ModelConfigurations;

public class CountryCategoryConfiguration : IEntityTypeConfiguration<CountryCategory>
{
    public void Configure(EntityTypeBuilder<CountryCategory> builder)
    {
    }
}
