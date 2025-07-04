using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;
using webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Transform;

public class UpdateHealthDataCommandFromResourceAssembler
{
    public static UpdateHealthDataCommand ToCommand(UpdateHealthDataResource resource) =>
        new UpdateHealthDataCommand(
            resource.HeartRate,
            resource.Temperature,
            resource.Weight,
            resource.OxygenSaturation
        );
}