using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

namespace webexperts.helpmom.platform.API.PatientManagement.Application.Internal.QueryServices;

public class PatientQueryService(IPatientRepository patientRepository) : IPatientQueryService
{
    public async Task<Patient?> Handle(GetPatientByIdQuery query)
    {
        return await patientRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Patient>> Handle(GetAllPatientsByAssignedDoctorIdQuery query)
    {
        return await patientRepository.FindByAssignedDoctorIdAsync(query.AssignedDoctorId);
    }

    public async Task<Patient?> Handle(GetPatientByProfileIdQuery query)
    {
        return await patientRepository.FindByProfileIdAsync(query.ProfileId);
    }
}