using Ookly.Core.CountryAggregate;

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
    string sourceUrl,
    string countryId,
    string categoryId,
    string pictureUrl,
    string title,
    string? description,
    long price
    ) : Entity<Guid>(id), IAggregateRoot
{

    public Ad(
        AdStatus status,
        string sourceUrl,
        Country country,
        Category category,
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

    public AdStatus Status { get; private set; } = status;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ProcessedAt { get; private set; }

    public string SourceUrl { get; private set; } = sourceUrl;

    public string CountryId { get; private set; } = countryId;
    public Country Country { get; private set; } = default!;

    public string CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;

    public string PictureUrl { get; private set; } = pictureUrl;
    public string Title { get; private set; } = title;
    public string? Description { get; private set; } = description!;
    public long Price { get; private set; } = price;
    public List<AdProperty> Properties { get; private set; } = [];

    public void SetActive()
    {
        Status = AdStatus.Active;
    }

    public void UpdateProcessedAt()
    {
        ProcessedAt = DateTime.UtcNow;
    }

    public void AddProperty(AdProperty property)
    {
        Properties.Add(property);
    }

    public void AddProperties(List<AdProperty> properties)
    {
        Properties.AddRange(properties);
    }
}
