using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<IEnumerable<Patient>> FindByAssignedDoctorIdAsync(int assignedDoctorId);
    
    Task<Patient?> FindByProfileIdAsync(int profileId);
}