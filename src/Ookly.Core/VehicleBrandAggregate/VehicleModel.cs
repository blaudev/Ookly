namespace Ookly.Core.VehicleBrandAggregate;

public class VehicleModel(Guid id, string name) : Entity(id)
{
    public string Name { get; private set; } = name;
}
