using Ookly.Core.Entities.CountryEntity;

namespace Ookly.Core.Entities.ListingEntity;

public enum ListingStatus
{
    Pending = 1,
    Updating,
    Active,
    Error
};

public class Listing(
    Guid id,
    ListingStatus status,
    string sourceUrl,
    string countryId,
    string categoryId,
    string pictureUrl,
    string title,
    string? description,
    long price
    ) : Entity<Guid>(id), IAggregateRoot
{

    public Listing(
        ListingStatus status,
        string sourceUrl,
        Country country,
        CountryCategory category,
        string pictureUrl,
        string title,
        long price
    ) : this(
        Guid.NewGuid(),
        status,
        sourceUrl,
        country.Id,
        category.Id,
        pictureUrl,
        title,
        null,
        price
    )
    {
        Country = country;
        Category = category;
    }

    public ListingStatus Status { get; private set; } = status;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ProcessedAt { get; private set; }

    public string SourceUrl { get; private set; } = sourceUrl;

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string CategoryId { get; private set; } = categoryId;
    public CountryCategory Category { get; private set; } = default!;

    public string PictureUrl { get; private set; } = pictureUrl;
    public string Title { get; private set; } = title;
    public string? Description { get; private set; } = description!;
    public long Price { get; private set; } = price;
    public List<ListingDetail> Properties { get; private set; } = [];

    public void SetActive()
    {
        Status = ListingStatus.Active;
    }

    public void UpdateProcessedAt()
    {
        ProcessedAt = DateTime.UtcNow;
    }

    public void AddProperty(ListingDetail property)
    {
        Properties.Add(property);
    }

    public void AddProperties(List<ListingDetail> properties)
    {
        Properties.AddRange(properties);
    }

}
