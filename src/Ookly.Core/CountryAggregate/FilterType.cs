namespace Ookly.Core.CountryAggregate;

public enum FilterTypeValueType
{
    Text,
    Numeric,
    Boolean
}

public class FilterType(string id, FilterTypeValueType valueType) : Entity<string>(id)
{
    public FilterTypeValueType ValueType { get; private set; } = valueType;
}
