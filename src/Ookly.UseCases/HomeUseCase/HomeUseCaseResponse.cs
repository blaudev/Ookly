using Blau.UseCases;
using Ookly.Core.Entities;

namespace Ookly.UseCases.HomeUseCase;

public record HomeUseCaseResponse(List<Country> Countries) : IUseCaseResponse;

public record Country(string Id, List<Category> Categories)
{
    public static Country Map(Core.Entities.Country country)
    {
        return new Country(country.Id, country.Categories.Select(Category.Map).ToList());
    }

    public static List<Country> Map(List<Core.Entities.Country> countries)
    {
        return countries.Select(Map).ToList();
    }
}

public record Category(string Id)
{
    public static Category Map(CountryCategory category)
    {
        return new Category(category.CategoryId);
    }
}
