using Blau.UseCases;

using Ookly.Core.Entities;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseRequest(CountryCategory category, Dictionary<string, string> filters) : IUseCaseRequest
{
    public CountryCategory Category { get; private set; } = category;
    public Dictionary<string, string> Filters { get; private set; } = filters;
}
