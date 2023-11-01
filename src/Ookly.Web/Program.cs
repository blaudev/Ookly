using Ookly.Core.Interfaces;
using Ookly.Infrastructure;
using Ookly.Infrastructure.Elastic;
using Ookly.Infrastructure.EntityFramework.Repositories;
using Ookly.UseCases.HomeUseCase;
using Ookly.UseCases.SearchUseCase;
using Ookly.Web.ModelBinders;
using Ookly.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddElastic(builder.Configuration);

builder.Services.AddSingleton<IAdDocumentRepository, AdDocumentRepository>();
builder.Services.AddScoped<IAdRepository, AdRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<SeedTestDataService>();

builder.Services.AddScoped<HomeUseCaseHandler>();
builder.Services.AddScoped<SearchUseCaseHandler>();

builder.Services.AddScoped<SearchUseCaseRequestModelBinder>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

if (app.Environment.IsDevelopment())
{
    app.SeedTestData();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
