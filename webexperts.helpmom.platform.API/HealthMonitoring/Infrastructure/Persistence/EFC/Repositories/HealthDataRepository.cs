using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class HealthDataRepository(AppDbContext context) : 
    BaseRepository<HealthData>(context), IHealthMonitoringRepository
{
    public async Task<IEnumerable<HealthData>> FindByPatientIdAsync(int patientId)
    {
        return await Context.Set<HealthData>().Where(h => h.PatientId == patientId).ToListAsync();
    }
}