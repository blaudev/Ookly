using Blau.UseCases;

using Ookly.Core.Entities;

namespace Ookly.UseCases.HomeUseCase;

public record HomeUseCaseResponse(List<Country> Countries) : IUseCaseResponse;

public record Country(string Name, List<Category> Categories)
{
    public static Country Map(Core.Entities.Country country)
    {
        return new Country(country.Name, country.CountryCategories.Select(Category.Map).ToList());
    }

    public static List<Country> Map(List<Core.Entities.Country> countries)
    {
        return countries.Select(Map).ToList();
    }
}

public record Category(string Name)
{
    public static Category Map(CountryCategory category)
    {
        return new Category(category.Category.Name);
    }
}
