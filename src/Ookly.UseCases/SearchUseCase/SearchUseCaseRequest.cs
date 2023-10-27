using Blau.UseCases;
using Blau.Validations;

namespace Ookly.UseCases.SearchUseCase;

public record SearchUseCaseRequest(string CountryId, string CategoryId, Dictionary<string, string> Filters) : IUseCaseRequest, IValidable
{
    public void Validate()
    {
        Validator.NotEmpty(() => CountryId);
        Validator.NotEmpty(() => CategoryId);
    }
}
