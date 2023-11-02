using Blau.UseCases;
using Ookly.Core.Entities.CountryEntity;

namespace Ookly.UseCases.HomeUseCase;

public class HomeUseCaseHandler(ICountryRepository countryRepository) : IUseCaseHandler<HomeUseCaseResponse>
{
    public async Task<HomeUseCaseResponse> HandleAsync()
    {
        return new(Country.Map(await countryRepository.GetCountryStatsAsync()));
    }
}
