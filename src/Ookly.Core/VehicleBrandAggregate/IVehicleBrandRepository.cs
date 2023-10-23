using Ookly.Core.Interfaces;

namespace Ookly.Core.VehicleBrandAggregate;

public interface IVehicleBrandRepository : IRepository<VehicleBrand>
{
    Task<VehicleBrand> ByNameAsync(string brandName);
}
