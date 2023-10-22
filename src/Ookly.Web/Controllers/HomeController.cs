using Ookly.UseCases.GetCountryStats;
using Ookly.Web.ViewModels;

namespace Ookly.Web.Controllers;

public class HomeController(GetCountryStatsHandler getCountryStatsHandler) : Controller
{
    public async Task<IActionResult> Home()
    {
        var countries = (await getCountryStatsHandler.HandleAsync()).Countries;
        var model = new HomeViewModel(countries);
        return View(model);
    }
}
