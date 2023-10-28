using Ookly.Core.CountryAggregate;

namespace Ookly.Core.AdAggregate;

public class AdProperty(
    Guid adId,
    string filterTypeId,
    string? textValue = null,
    decimal? numericValue = null,
    bool? booleanValue = null) : Entity<Guid>(Guid.NewGuid())
{
    public AdProperty(Ad ad, FilterType filterType, object value) : this(ad.Id, filterType.Id)
    {
        Ad = ad;
        FilterType = filterType;

        switch (filterType, value)
        {
            case ({ ValueType: FilterTypeValueType.Text }, string textValue):
                TextValue = textValue;
                break;
            case ({ ValueType: FilterTypeValueType.Numeric }, int numericValue):
                NumericValue = numericValue;
                break;
            case ({ ValueType: FilterTypeValueType.Numeric }, long numericValue):
                NumericValue = numericValue;
                break;
            case ({ ValueType: FilterTypeValueType.Boolean }, bool booleanValue):
                BooleanValue = booleanValue;
                break;
            default:
                throw new ArgumentException($"{value.GetType()} is not a valid {filterType.GetType}");
        }
    }

    public Guid AdId { get; private set; } = adId;
    public Ad Ad { get; private set; } = default!;

    public string FilterTypeId { get; private set; } = filterTypeId;
    public FilterType FilterType { get; private set; } = default!;

    public string? TextValue { get; private set; } = textValue;
    public decimal? NumericValue { get; private set; } = numericValue;
    public bool? BooleanValue { get; private set; } = booleanValue;
}
