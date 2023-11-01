using Ookly.Core.Entities;

namespace Ookly.Core.Interfaces;

public interface IVehicleBrandRepository : IRepository<VehicleBrand>
{
    Task<VehicleBrand> WithModelsAsync(string brandName);
}
