using Blau.UseCases;

using Ookly.Core.Entities;

namespace Ookly.UseCases.SearchUseCase;

public class SearchUseCaseRequest : IUseCaseRequest
{
    public string CountryId { get; init; } = string.Empty;
    public string CategoryId { get; init; } = string.Empty;
    public CountryCategory CountryCategory { get; init; } = new();
    public Dictionary<string, string> FilterValues { get; init; } = [];
}
