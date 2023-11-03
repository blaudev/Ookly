using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.Controllers;

public class SearchController(SearchUseCaseHandler useCase) : Controller
{
    [HttpGet("search")]
    public async Task<IActionResult> Search(SearchUseCaseRequest request) =>
        View(await useCase.HandleAsync(request));
}

public class ApiSearchController(SearchUseCaseHandler useCase) : ControllerBase
{
    [HttpGet("api/search")]
    public async Task<SearchUseCaseResponse> Search(SearchUseCaseRequest request) =>
        await useCase.HandleAsync(request);
}