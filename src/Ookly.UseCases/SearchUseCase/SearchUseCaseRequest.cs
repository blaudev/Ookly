using Blau.UseCases;
using Blau.Validations;

namespace Ookly.UseCases.SearchUseCase;

public record SearchUseCaseRequest(string CountryName, string CategoryName, Dictionary<string, string> Filters) : IUseCaseRequest, IValidable
{
    public void Validate()
    {
        Validator.NotEmpty(() => CountryName);
        Validator.NotEmpty(() => CategoryName);
    }
}
