namespace Ookly.Core.CountryAggregate;

public enum FilterTypeValueType
{
    String,
    Number,
    Boolean
}

public class FilterType(string id, FilterTypeValueType valueType) : Entity<string>(id)
{
    public FilterTypeValueType ValueType { get; private set; } = valueType;
}
