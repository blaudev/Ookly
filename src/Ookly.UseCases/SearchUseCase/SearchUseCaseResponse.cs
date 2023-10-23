using Blau.UseCases;

namespace Ookly.UseCases.SearchUseCase;

public record SearchUseCaseResponse(
    string CountryName,
    string CategoryName,
    Dictionary<string, string> Filters,
    List<Facet> Facets,
    long AdCount,
    Ad[] Ads) : IUseCaseResponse;

public record Facet(string Name, string FilterName, List<FacetItem> Items);

public record FacetItem(string Text, string Value);

public record Ad(
    int Id,
    string Title,
    string PictureUrl,
    long Price,
    int CurrencyId);
