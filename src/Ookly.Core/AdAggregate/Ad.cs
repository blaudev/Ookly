using Ookly.Core.CountryAggregate;
using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.Core.AdAggregate;

public enum AdStatus
{
    Pending = 1,
    Updating,
    Active,
    Error
};

public class Ad(
    Guid id,
    AdStatus status,
    string categoryId,
    string sourceUrl,
    string title,
    string pictureUrl,
    string? description,
    long price,
    string countryId,
    string? state,
    string? city,
    string? vehicleBrandId,
    string? vehicleModelId,
    int? vehicleYear,
    int? vehicleMileage,
    string? vehicleFuelType,
    string? vehicleColor,
    int? surface,
    int? bedrooms,
    int? bathrooms,
    bool? pets,
    bool? furnished
    ) : Entity<Guid>(id), IAggregateRoot
{

    public AdStatus Status { get; private set; } = status;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ProcessedAt { get; private set; }

    public string CategoryId { get; private set; } = categoryId;
    public CategoryType Category { get; private set; } = default!;

    public string SourceUrl { get; private set; } = sourceUrl;

    public string Title { get; private set; } = title;
    public string PictureUrl { get; private set; } = pictureUrl;
    public string? Description { get; private set; } = description!;

    public long Price { get; private set; } = price;

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string? State { get; private set; } = state;
    public string? City { get; private set; } = city;

    public string? VehicleBrandId { get; private set; } = vehicleBrandId;
    public VehicleBrand? VehicleBrand { get; private set; }

    public string? VehicleModelId { get; private set; } = vehicleModelId;
    public VehicleModel? VehicleModel { get; private set; }

    public int? VehicleYear { get; private set; } = vehicleYear;
    public int? VehicleMileage { get; private set; } = vehicleMileage;
    public string? VehicleFuelType { get; private set; } = vehicleFuelType;
    public string? VehicleColor { get; private set; } = vehicleColor;

    public int? Surface { get; private set; } = surface;
    public int? Bedrooms { get; private set; } = bedrooms;
    public int? Bathrooms { get; private set; } = bathrooms;
    public bool? Pets { get; private set; } = pets;
    public bool? Furnished { get; private set; } = furnished;

    public void SetActive()
    {
        Status = AdStatus.Active;
    }

    public void UpdateProcessedAt()
    {
        ProcessedAt = DateTime.UtcNow;
    }
}
