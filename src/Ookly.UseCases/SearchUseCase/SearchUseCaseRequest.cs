using Blau.UseCases;
using Ookly.Core.Entities;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseRequest(string countryId, string categoryId, Dictionary<string, string> filterValues, CountryCategory countryCategory) : IUseCaseRequest
{
    public string CountryId { get; private set; } = countryId;
    public string CategoryId { get; private set; } = categoryId;
    public CountryCategory CountryCategory { get; private set; } = countryCategory;
    public Dictionary<string, string> FilterValues { get; private set; } = filterValues;
}
