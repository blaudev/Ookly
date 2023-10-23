using Microsoft.AspNetCore.Mvc.ModelBinding;

using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.ModelBinders;

public class SearchUseCaseRequestModelBinder : IModelBinder
{
    private static readonly string[] filterNames = ["VehicleBrand", "VehicleModel"];

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var countryName = bindingContext.ValueProvider.GetValue("CountryName").FirstValue ?? string.Empty;
        var categoryName = bindingContext.ValueProvider.GetValue("CategoryName").FirstValue ?? string.Empty;
        var filters = GetFilters(bindingContext);

        bindingContext.Result = ModelBindingResult.Success(new SearchUseCaseRequest(countryName, categoryName, filters));
        await Task.CompletedTask;
    }

    private Dictionary<string, string> GetFilters(ModelBindingContext bindingContext)
    {
        return filterNames
            .ToDictionary(k => k, v => bindingContext.ValueProvider.GetValue(v).FirstValue ?? string.Empty)
            .Where(i => i.Value != string.Empty)
            .ToDictionary(k => k.Key, v => v.Value);
    }
}
