using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Infrastructure.Persistence.EFC.Repositories;

public class PatientRepository(AppDbContext context) : BaseRepository<Patient>(context), IPatientRepository 
{
    public async Task<IEnumerable<Patient>> FindByAssignedDoctorIdAsync(int assignedDoctorId)
    {
        return await Context.Set<Patient>()
            .Include(patient => patient.AssignedDoctor)
            .Where(patient => patient.AssignedDoctorId == assignedDoctorId)
            .ToListAsync();
    }

    public async Task<Patient?> FindByProfileIdAsync(int profileId)
    {
        return await Context.Set<Patient>()
            .FirstOrDefaultAsync(patient => patient.ProfileId.Id == profileId);
    }
    
}