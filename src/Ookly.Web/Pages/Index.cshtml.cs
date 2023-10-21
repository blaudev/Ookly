using Ookly.UseCases.GetCountryStats;

namespace Ookly.Web.Pages;

public class IndexModel : PageModel
{
    private readonly GetCountryStatsHandler _getCountryStatsHandler;

    public IndexModel(GetCountryStatsHandler getCountryStatsHandler)
    {
        _getCountryStatsHandler = getCountryStatsHandler;
    }

    public IReadOnlyCollection<Country> Countries { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Countries = (await _getCountryStatsHandler.HandleAsync()).Countries;
    }
}
