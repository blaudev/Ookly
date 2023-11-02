using Blau.UseCases;
using Ookly.Core.Entities.CountryEntity;

namespace Ookly.UseCases.HomeUseCase;

public record HomeUseCaseResponse(List<Country> Countries) : IUseCaseResponse;

public record Country(string Id, List<Category> Categories)
{
    public static Country Map(Core.Entities.CountryEntity.Country country)
    {
        return new Country(country.Id, country.CountryCategories.Select(Category.Map).ToList());
    }

    public static List<Country> Map(List<Core.Entities.CountryEntity.Country> countries)
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
