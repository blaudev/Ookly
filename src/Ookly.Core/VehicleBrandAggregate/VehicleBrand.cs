namespace Ookly.Core.VehicleBrandAggregate;

public class VehicleBrand(string id) : Entity<string>(id), IAggregateRoot
{
    public List<VehicleModel> VehicleModels { get; private set; } = [];

    public void AddModel(VehicleModel model)
    {
        VehicleModels.Add(model);
    }

    public void AddModels(List<VehicleModel> models)
    {
        VehicleModels.AddRange(models);
    }
}
