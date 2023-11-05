using Ookly.Core.Entities.ListingEntity;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class AdRepository(ApplicationContext context) : ApplicationRepository<Listing>(context), IListingRepository
{
    public Task<List<Listing>> SearchAsync(Dictionary<string, string> filters)
    {
        throw new NotImplementedException();
    }

    //private IQueryable<Ad> MakeQuery(Dictionary<string, string> filters)
    //{
    //    var query = context.Ads
    //        .Where(q => q.Status == Domain.Entities.AdStatus.Active)
    //        .Where(q => q.CountryId == filter.CountryId)
    //        .Where(q => q.CategoryId == filter.CategoryId);
    //}
}
