using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

public interface IPatientQueryService
{
    Task<Patient?> Handle(GetPatientByIdQuery query);
    Task<IEnumerable<Patient>> Handle(GetAllPatientsByAssignedDoctorIdQuery query);
    Task<Patient?> Handle(GetPatientByProfileIdQuery query);
}