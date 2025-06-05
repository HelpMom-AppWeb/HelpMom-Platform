using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;

public interface IHealthDataQueryService
{
    Task<HealthData?> Handle (GetHealthDataByIdQuery query);

    Task<IEnumerable<HealthData>> Handle(GetAllHealthDataQuery query);

    Task<IEnumerable<HealthData>> Handle(GetHealthDataByPatientIdQuery query);
}