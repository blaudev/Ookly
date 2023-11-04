namespace Ookly.Core.Entities;

public class Country : Entity, IAggregateRoot
{
    public string Name { get; init; } = string.Empty;

    public List<CountryCategory> CountryCategories { get; init; } = [];
}
