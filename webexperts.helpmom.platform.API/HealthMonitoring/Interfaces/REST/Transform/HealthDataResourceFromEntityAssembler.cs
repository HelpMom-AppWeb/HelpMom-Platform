using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Transform;

public static class HealthDataResourceFromEntityAssembler
{
    public static HealthDataResource ToResourceFromEntity(HealthData entity) =>
        new HealthDataResource(entity.Id, entity.HeartRate, entity.Temperature, entity.Weight, entity.OxygenSaturation,
            entity.PatientId);
}