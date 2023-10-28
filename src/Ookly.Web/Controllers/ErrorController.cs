using Ookly.Web.ViewModels;

using System.Diagnostics;

namespace Ookly.Web.Controllers;

public class ErrorController : Controller
{
    [HttpGet("/Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}