namespace Ookly.Core.AdDocumentAggregate;

public class AdDocument(
    Guid id,
    string countryId,
    string categoryId,
    string pictureUrl,
    string title,
    string? description,
    long price,
    Dictionary<string, object> properties
    ) : Entity<Guid>(id), IAggregateRoot
{
    public string CountryId { get; private set; } = countryId;
    public string CategoryId { get; private set; } = categoryId;
    public string PictureUrl { get; private set; } = pictureUrl;
    public string Title { get; private set; } = title;
    public string? Description { get; private set; } = description!;
    public long Price { get; private set; } = price;
    public Dictionary<string, object> Properties { get; private set; } = properties;
}
