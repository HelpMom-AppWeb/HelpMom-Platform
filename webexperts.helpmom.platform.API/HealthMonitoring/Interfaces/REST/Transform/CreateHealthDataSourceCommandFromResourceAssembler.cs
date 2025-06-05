using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;
using webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Transform;

public static class CreateHealthDataSourceCommandFromResourceAssembler
{
    public static CreateHealthDataCommand ToCommandFromResource(CreateHealthDataResource resource) =>
        new CreateHealthDataCommand(resource.HeartRate, resource.Temperature, resource.Weight,
            resource.OxygenSaturation, resource.PatientId);
}