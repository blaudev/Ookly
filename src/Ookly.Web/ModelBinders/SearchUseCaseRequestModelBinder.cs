using Microsoft.AspNetCore.Mvc.ModelBinding;

using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.ModelBinders;

public class SearchUseCaseRequestModelBinder : IModelBinder
{
    private static readonly string[] filterNames = ["VehicleBrand", "VehicleModel", "VehicleYear", "VehicleMileage", "VehicleFuelType", "VehicleColor"];

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var countryId = bindingContext.ValueProvider.GetValue("country").FirstValue ?? string.Empty;
        var categoryId = bindingContext.ValueProvider.GetValue("category").FirstValue ?? string.Empty;
        var filters = GetFilters(bindingContext);

        bindingContext.Result = ModelBindingResult.Success(new SearchUseCaseRequest(countryId, categoryId, filters));
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
