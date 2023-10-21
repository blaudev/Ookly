using Ookly.Core.CountryAggregate;

namespace Ookly.UseCases.GetCountryStats;

public class GetCountryStatsHandler(ICountryRepository countryRepository)
{
    public async Task<GetCountryStatsResponse> HandleAsync()
    {
        var countries = await countryRepository.GetCountryStatsAsync();
        var mappedCountries = countries.Select(Country.Map).ToList();

        return new(mappedCountries);
    }
}
