namespace Ookly.Core.Entities;

public class Country : NamedEntity, IAggregateRoot
{
    public List<CountryCategory> CountryCategories { get; init; } = [];
}
