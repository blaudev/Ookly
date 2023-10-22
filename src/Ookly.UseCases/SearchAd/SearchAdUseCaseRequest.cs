using Blau.UseCases;
using Blau.Validations;

namespace Ookly.UseCases.SearchAd;

public record SearchAdUseCaseRequest : IUseCaseRequest, IValidable
{
    public string? CountryName { get; init; }
    public string? CategoryName { get; init; }

    public void Validate()
    {
        Validator.NotEmpty(() => CountryName);
        Validator.NotEmpty(() => CategoryName);
    }
}
