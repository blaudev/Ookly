using Blau.UseCases;

using Ookly.Core.CountryAggregate;

namespace Ookly.UseCases.HomeUseCase;

public class HomeUseCaseHandler(ICountryRepository countryRepository) : IUseCaseHandler<HomeUseCaseResponse>
{
    public async Task<HomeUseCaseResponse> HandleAsync()
    {
        return new(Country.Map(await countryRepository.GetCountryStatsAsync()));
    }
}
