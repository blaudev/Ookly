using Ookly.UseCases.SearchAd;

namespace Ookly.Web.Controllers;

public class SearchAdController(SearchAdUseCaseHandler useCase) : Controller
{
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] SearchAdUseCaseRequest request) =>
        View(await useCase.HandleAsync(request));
}
