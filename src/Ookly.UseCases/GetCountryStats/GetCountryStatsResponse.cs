﻿namespace Ookly.UseCases.GetCountryStats;

public record GetCountryStatsResponse(List<Country> Countries);

public record Country(string Name, IReadOnlyCollection<Category> Categories)
{
    public static Country Map(Core.CountryAggregate.Country country)
    {
        return new Country(country.Name, country.Categories.Select(Category.Map).ToList());
    }
}

public record Category(string Name)
{
    public static Category Map(Core.CategoryAggregate.Category category)
    {
        return new Category(category.Name);
    }
}