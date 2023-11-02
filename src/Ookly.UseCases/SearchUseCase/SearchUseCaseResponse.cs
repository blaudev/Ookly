using Blau.UseCases;

using Ookly.Core.Services.SearchService.Models;

namespace Ookly.UseCases.SearchUseCase;

public record SearchUseCaseResponse(
    string CountryId,
    string CategoryId,
    Dictionary<string, string> Filters,
    List<Facet>? Facets,
    long AdCount,
    Ad[] Ads) : IUseCaseResponse;

public record Ad(
    int Id,
    string Title,
    string PictureUrl,
    long Price,
    int CurrencyId);
