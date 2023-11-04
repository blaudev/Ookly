namespace Ookly.Core.Entities;

public class CategoryFilter : Entity
{
    public int CountryCategoryId { get; init; }
    public CountryCategory CountryCategory { get; init; } = new();

    public int FilterId { get; init; }
    public Filter Filter { get; init; } = new();
}
