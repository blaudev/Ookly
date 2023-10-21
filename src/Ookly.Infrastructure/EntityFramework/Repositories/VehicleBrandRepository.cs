using Ookly.Core.VehicleBrandAggregate;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class VehicleBrandRepository(ApplicationContext context) : Repository<VehicleBrand>(context), IVehicleBrandRepository
{
}
