namespace Ookly.Core.VehicleBrandAggregate;

public class VehicleBrand(Guid id, string name) : Entity(id), IAggregateRoot
{
    public string Name { get; private set; } = name;
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
