using Blau.Exceptions;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using Ookly.Core.Interfaces;
using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.ModelBinders;

public class SearchUseCaseRequestModelBinder(
    ICountryRepository countryRepository,
    ICategoryRepository categoryRepository,
    ICountryCategoryRepository countryCategoryRepository) : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var countryName = bindingContext.ValueProvider.GetValue("country").FirstValue ?? throw new ValidationException("country");
        var country = await countryRepository.FirstByNameAsync(countryName);

        var categoryName = bindingContext.ValueProvider.GetValue("category").FirstValue ?? throw new ValidationException("country");
        var category = await categoryRepository.FirstByNameAsync(categoryName);

        var countryCategory = await countryCategoryRepository.FirstByCountryIdAndCategoryIdAsync(country.Id, category.Id);

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
