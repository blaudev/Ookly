using Ookly.Core.CountryAggregate;

namespace Ookly.UseCases.GetCountryStats;

public class GetCountryStatsHandler(ICountryRepository countryRepository)
{
    public async Task<GetCountryStatsResponse> HandleAsync()
    {
        return new(Country.Map(await countryRepository.GetCountryStatsAsync()));
    }
}
