namespace Ookly.Core.CountryAggregate;

public class Facet(string filterId, string key, string value) : Entity<string>($"{filterId}_{key}")
{
    public Facet(Filter filter, string key, string value) : this(filter.Id, key, value)
    {
        Filter = filter;
    }

    public string FilterId { get; private set; } = filterId;
    public Filter Filter { get; private set; } = default!;

    public string Key { get; private set; } = key;
    public string Value { get; private set; } = value;
}
