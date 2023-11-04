using Blau.Exceptions;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ookly.Core.Interfaces;
using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.ModelBinders;

public class SearchUseCaseRequestModelBinder(ICountryRepository countryRepository) : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var countryId = bindingContext.ValueProvider.GetValue("country").FirstValue ?? string.Empty;
        var categoryId = bindingContext.ValueProvider.GetValue("category").FirstValue ?? string.Empty;

        var country = await countryRepository.GetCountryWithCountryCategoriesAndFiltersAsync(countryId);

        var countryCategory = country.Categories.FirstOrDefault(x => x.CategoryId == categoryId)
            ?? throw new ValidationException(categoryId);

        var categoryFilterIds = countryCategory.CategoryFilters.Select(x => x.FilterId).ToList();
        var filterValues = GetFilterValues(categoryFilterIds, bindingContext);

        bindingContext.Result = ModelBindingResult.Success(new SearchUseCaseRequest(countryId, categoryId, filterValues, countryCategory));
        await Task.CompletedTask;
    }

    private static Dictionary<string, string> GetFilterValues(List<string> categoryFilterIds, ModelBindingContext bindingContext)
    {
        return categoryFilterIds
            .ToDictionary(k => k, v => bindingContext.ValueProvider.GetValue(v).FirstValue ?? string.Empty)
            .Where(i => i.Value != string.Empty)
            .ToDictionary(k => k.Key, v => v.Value);
    }
}
