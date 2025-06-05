using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Domain.Repositories;

public interface IHealthMonitoringRepository : IBaseRepository<Model.Aggregates.HealthData>
{

    Task<IEnumerable<HealthData>> FindByPatientIdAsync(int patientId);
    
}