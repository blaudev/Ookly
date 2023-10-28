using Ookly.UseCases.SearchUseCase;
using Ookly.Web.ModelBinders;

namespace Ookly.Web.Controllers;

public class SearchController(SearchUseCaseHandler useCase) : Controller
{
    [HttpGet("search")]
    public async Task<IActionResult> Search([ModelBinder(BinderType = typeof(SearchUseCaseRequestModelBinder))] SearchUseCaseRequest request) =>
        View(await useCase.HandleAsync(request));
}

[ApiController]
public class ApiSearchController(SearchUseCaseHandler useCase) : Controller
{
    [HttpGet("api/search")]
    public async Task<SearchUseCaseResponse> Search([ModelBinder(BinderType = typeof(SearchUseCaseRequestModelBinder))] SearchUseCaseRequest request) =>
        await useCase.HandleAsync(request);
}