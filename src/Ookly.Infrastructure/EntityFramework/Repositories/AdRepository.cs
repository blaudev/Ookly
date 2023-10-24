using Ookly.Core.AdAggregate;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class AdRepository(ApplicationContext context) : Repository<Ad>(context), IAdRepository
{
    public Task<List<Ad>> SearchAsync(Dictionary<string, string> filters)
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
