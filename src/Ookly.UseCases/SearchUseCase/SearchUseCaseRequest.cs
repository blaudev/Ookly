using Blau.UseCases;

using Ookly.Core.Entities;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseRequest : IUseCaseRequest
{
    public string CountryId { get; private set; } = string.Empty;
    public string CategoryId { get; private set; } = string.Empty;
    public CountryCategory CountryCategory { get; private set; } = new();
    public Dictionary<string, string> FilterValues { get; private set; } = [];
}
