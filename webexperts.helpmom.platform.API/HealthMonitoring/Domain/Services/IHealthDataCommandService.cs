using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;

public interface IHealthDataCommandService
{
    Task<HealthData?> Handle(CreateHealthDataCommand command);
}