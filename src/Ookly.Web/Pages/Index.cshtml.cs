using Ookly.UseCases.GetCountryStats;

namespace Ookly.Web.Pages;

public class IndexModel(GetCountryStatsHandler getCountryStatsHandler) : PageModel
{
    public IReadOnlyCollection<Country> Countries { get; private set; } = [];

    public async Task OnGetAsync() =>
        Countries = (await getCountryStatsHandler.HandleAsync()).Countries;
}
