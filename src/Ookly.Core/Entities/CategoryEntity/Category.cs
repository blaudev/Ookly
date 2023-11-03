using Ookly.Core.Entities.CountryEntity;
using Ookly.Core.Entities.FilterEntity;

namespace Ookly.Core.Entities.CategoryEntity;

public class Category(string id) : Entity<string>(id)
{
    public List<Filter> Filters { get; private set; } = [];
    public List<CountryCategory> CountryCategories { get; private set; } = [];
}
