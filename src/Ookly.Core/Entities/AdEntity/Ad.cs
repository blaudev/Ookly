using Ookly.Core.Entities.CountryEntity;
using Ookly.Core.Entities.FilterEntity;

namespace Ookly.Core.Entities.AdEntity;

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

    public AdStatus Status { get; private set; } = status;

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

public class AdProperty(
    Guid adId,
    string filterId,
    string? textValue = null,
    decimal? numericValue = null,
    bool? booleanValue = null) : Entity<Guid>(Guid.NewGuid())
{
    public AdProperty(Ad ad, Filter filterType, object value) : this(ad.Id, filterType.Id)
    {
        Ad = ad;
        FilterType = filterType;

        switch (filterType, value)
        {
            case ({ ValueType: FilterEntity.FilterType.Text }, string textValue):
                TextValue = textValue;
                break;
            case ({ ValueType: FilterEntity.FilterType.Numeric }, int numericValue):
                NumericValue = numericValue;
                break;
            case ({ ValueType: FilterEntity.FilterType.Numeric }, long numericValue):
                NumericValue = numericValue;
                break;
            case ({ ValueType: FilterEntity.FilterType.Boolean }, bool booleanValue):
                BooleanValue = booleanValue;
                break;
            default:
                throw new ArgumentException($"{value.GetType()} is not a valid {filterType.GetType}");
        }
    }

    public Guid AdId { get; private set; } = adId;
    public Ad Ad { get; private set; } = default!;

    public string FilterId { get; private set; } = filterId;
    public Filter FilterType { get; private set; } = default!;

    public string? TextValue { get; private set; } = textValue;
    public decimal? NumericValue { get; private set; } = numericValue;
    public bool? BooleanValue { get; private set; } = booleanValue;
}
