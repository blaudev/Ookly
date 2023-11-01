using Microsoft.EntityFrameworkCore;
using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class VehicleBrandRepository(ApplicationContext context) : Repository<VehicleBrand>(context), IVehicleBrandRepository
{
    public async Task<VehicleBrand> WithModelsAsync(string brandId)
    {
        return await context.VehicleBrands
            .Include(i => i.VehicleModels.OrderBy(o => o.Id))
            .FirstAsync(o => o.Id == brandId);
    }
}
