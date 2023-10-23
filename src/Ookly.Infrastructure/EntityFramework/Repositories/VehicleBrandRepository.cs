using Microsoft.EntityFrameworkCore;

using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class VehicleBrandRepository(ApplicationContext context) : Repository<VehicleBrand>(context), IVehicleBrandRepository
{
    public async Task<VehicleBrand> ByNameAsync(string brandName)
    {
        return await context.VehicleBrands
            .Include(i => i.VehicleModels.OrderBy(o => o.Name))
            .FirstAsync(o => o.Name == brandName);
    }
}
