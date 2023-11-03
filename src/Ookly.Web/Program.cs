using Ookly.Core.Entities.AdEntity;
using Ookly.Core.Entities.CountryEntity;
using Ookly.Core.Services.AdElasticIndexService;
using Ookly.Core.Services.AdSearchService;
using Ookly.Infrastructure;
using Ookly.Infrastructure.Elastic;
using Ookly.Infrastructure.Elastic.Services;
using Ookly.Infrastructure.EntityFramework.Repositories;
using Ookly.UseCases.HomeUseCase;
using Ookly.UseCases.SearchUseCase;
using Ookly.Web.ModelBinders;
using Ookly.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddElastic(builder.Configuration);

builder.Services.AddSingleton<IAdSearchService, ElasticAdSearchService>();
builder.Services.AddSingleton<IElasticAdIndexService, ElasticAdIndexService>();

builder.Services.AddScoped<IAdRepository, AdRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<SeedTestDataService>();

builder.Services.AddScoped<HomeUseCaseHandler>();
builder.Services.AddScoped<SearchUseCaseHandler>();

builder.Services.AddScoped<SearchUseCaseRequestModelBinder>();

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new SearchUseCaseRequestModelBinderProvider());
});

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
