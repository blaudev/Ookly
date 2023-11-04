namespace Ookly.Core.Entities.ListingEntity;

public class ListingDetail(
    Guid adId,
    string filterId,
    string? textValue = null,
    decimal? numericValue = null,
    bool? booleanValue = null) : Entity<Guid>(Guid.NewGuid())
{
    public ListingDetail(Listing ad, FilterValueType filterType, object value) : this(ad.Id, filterType.Id)
    {
        Ad = ad;
        FilterType = filterType;

        switch (filterType, value)
        {
            case ({ ValueType: FilterValueType.Text }, string textValue):
                TextValue = textValue;
                break;
            case ({ ValueType: FilterValueType.Numeric }, int numericValue):
                NumericValue = numericValue;
                break;
            case ({ ValueType: FilterValueType.Numeric }, long numericValue):
                NumericValue = numericValue;
                break;
            case ({ ValueType: FilterValueType.Boolean }, bool booleanValue):
                BooleanValue = booleanValue;
                break;
            default:
                throw new ArgumentException($"{value.GetType()} is not a valid {filterType.GetType}");
        }
    }

    public Guid AdId { get; private set; } = adId;
    public Listing Ad { get; private set; } = default!;

    public string FilterId { get; private set; } = filterId;
    public FilterValueType FilterType { get; private set; } = default!;

    public string? TextValue { get; private set; } = textValue;
    public decimal? NumericValue { get; private set; } = numericValue;
    public bool? BooleanValue { get; private set; } = booleanValue;
}
