using Blau.UseCases;
using Ookly.Core.Entities.CountryEntity;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseRequest(CountryCategory countryCategory, Dictionary<string, string> filterValues) : IUseCaseRequest
{
    public CountryCategory CountryCategory { get; private set; } = countryCategory;
    public Dictionary<string, string> FilterValues { get; private set; } = filterValues;
}
