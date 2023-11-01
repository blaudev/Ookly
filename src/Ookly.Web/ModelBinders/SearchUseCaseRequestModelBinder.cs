using Blau.Exceptions;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using Ookly.Core.Entities;
using Ookly.Core.Interfaces;
using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.ModelBinders;

public class SearchUseCaseRequestModelBinder(ICountryRepository countryRepository) : IModelBinder
{
    private static readonly string[] filterNames = ["VehicleBrand", "VehicleModel", "VehicleYear", "VehicleMileage", "VehicleFuelType", "VehicleColor"];

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var countryId = bindingContext.ValueProvider.GetValue("country").FirstValue ?? string.Empty;
        var categoryId = bindingContext.ValueProvider.GetValue("category").FirstValue ?? string.Empty;

        var country = await countryRepository.GetCountryWithCategoryAndFiltersAsync(countryId);

        var category = country.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (category == null)
        {
            throw new ValidationException(categoryId);
        }

        var filters = GetFilterValues(category.Filters, bindingContext);

        bindingContext.Result = ModelBindingResult.Success(new SearchUseCaseRequest(category, filters));
        await Task.CompletedTask;
    }

    private Dictionary<string, string> GetFilterValues(List<CategoryFilter> filters, ModelBindingContext bindingContext)
    {
        return filters.Select(x => x.FilterId)
            .ToDictionary(k => k, v => bindingContext.ValueProvider.GetValue(v).FirstValue ?? string.Empty)
            .Where(i => i.Value != string.Empty)
            .ToDictionary(k => k.Key, v => v.Value);
    }
}
