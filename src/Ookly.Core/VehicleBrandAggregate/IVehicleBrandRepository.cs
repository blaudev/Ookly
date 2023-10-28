using Ookly.Core.Interfaces;

namespace Ookly.Core.VehicleBrandAggregate;

public interface IVehicleBrandRepository : IRepository<VehicleBrand>
{
    Task<VehicleBrand> WithModelsAsync(string brandName);
}
