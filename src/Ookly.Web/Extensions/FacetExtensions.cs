using Microsoft.AspNetCore.Mvc.Rendering;

using Ookly.UseCases.SearchUseCase;

namespace Ookly.Web.Extensions;

public static class FacetExtensions
{
    public static List<SelectListItem> ToSelectListItems(this Facet facet)
    {
        return facet.Items.Select(item => new SelectListItem(item.Text, item.Value)).ToList();
    }
}
