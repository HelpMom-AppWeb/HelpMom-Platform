using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Repositories;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Application.Internal.CommandServices;

public class HealthDataCommandService(IHealthMonitoringRepository healthMonitoringRepository, IUnitOfWork unitOfWork) : IHealthDataCommandService
{
    public async Task<HealthData?> Handle(CreateHealthDataCommand command)
    {
        var healthData = new HealthData(command.HeartRate, command.Temperature, command.Weight,
            command.OxygenSaturation, command.PatientId);

        await healthMonitoringRepository.AddAsync(healthData);
        await unitOfWork.CompleteAsync();

        return healthData;

    }
    
}