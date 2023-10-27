using Ookly.Core.AdAggregate;

namespace Ookly.Core.CountryAggregate;

public class Category(string id) : Entity<string>(id)
{
    public List<Country> Countries { get; private set; } = [];
    public List<Filter> Filters { get; private set; } = [];
    public List<CountryCategoryFilter> CountryCategoryFilter { get; private set; } = [];
    public List<Ad> Ads { get; private set; } = [];

    public void AddFilter(Filter filter)
    {
        if (Filters.Any(x => x.Id == filter.Id))
        {
            return;
        }

        Filters.Add(filter);
    }
}
