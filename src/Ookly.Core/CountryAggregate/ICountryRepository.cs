namespace Ookly.Core.CountryAggregate;

public interface ICountryRepository
{
    Task<List<Country>> GetCountryStatsAsync();
}
