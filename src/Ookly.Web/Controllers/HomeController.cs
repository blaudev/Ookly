using Ookly.UseCases.HomeUseCase;

namespace Ookly.Web.Controllers;

public class HomeController(HomeUseCaseHandler useCase) : Controller
{
    public async Task<IActionResult> Home() =>
        View(await useCase.HandleAsync());
}
