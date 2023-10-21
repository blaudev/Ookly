using Ookly.Core.CountryAggregate;
using Ookly.Infrastructure.EntityFramework.Repositories;
using Ookly.UseCases.GetCountryStats;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFramework(builder.Configuration);

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<GetCountryStatsHandler>();

builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.Run();
