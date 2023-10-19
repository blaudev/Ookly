namespace Ookly.Web.Pages;

public class IndexModel : PageModel
{
    public IReadOnlyCollection<Country> Countries { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Countries = [new(1, "USA", [new(1, "Category 1"), new(2, "Category 2")])];

        await Task.CompletedTask;
    }
}

public record Country(int Id, string Name, IReadOnlyCollection<Category> Categories);

public record Category(int Id, string Name);
