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

        var countryName = bindingContext.ValueProvider.GetValue("country").FirstValue ?? throw new ValidationException("country");


        var categoryName = bindingContext.ValueProvider.GetValue("category").FirstValue ?? throw new ValidationException("country");

        var country = await countryRepository.GetCountryWithCountryCategoriesAndFiltersAsync(0);

        var countryCategory = country.CountryCategories.FirstOrDefault(x => x.Id == 0)
            ?? throw new ValidationException(categoryName);

        var categoryFilterIds = countryCategory.CategoryFilters.Select(x => x.Filter.Name).ToList();
        var filterValues = GetFilterValues(categoryFilterIds, bindingContext);

        bindingContext.Result = ModelBindingResult.Success(new SearchUseCaseRequest { CountryId = countryName, CategoryId = categoryName, FilterValues = filterValues });
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
