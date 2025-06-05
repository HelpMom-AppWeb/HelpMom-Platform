using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Queries;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Repositories;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Application.Internal.QueryServices;

public class HealthDataQueryService(IHealthMonitoringRepository healthMonitoringRepository) : IHealthDataQueryService
{
    public async Task<HealthData?> Handle(GetHealthDataByIdQuery query)
    {
        return await healthMonitoringRepository.FindByIdAsync(query.HealthDataId);
    }

    public async Task<IEnumerable<HealthData>> Handle(GetAllHealthDataQuery query)
    {
        return await healthMonitoringRepository.ListAsync();
    }

    public async Task<IEnumerable<HealthData>> Handle(GetHealthDataByPatientIdQuery query)
    {
        return await healthMonitoringRepository.FindByPatientIdAsync(query.PatientId);
    }
}