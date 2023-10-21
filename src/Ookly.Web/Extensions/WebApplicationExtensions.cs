using Ookly.Web.Services;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationExtensions
{
    public static WebApplication SeedTestData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<SeedTestDataService>();
        service.SeedAsync().Wait();

        return app;
    }
}
