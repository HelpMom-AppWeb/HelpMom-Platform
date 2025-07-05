using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

public interface IDoctorQueryService
{
    Task<Doctor?> Handle(GetDoctorByIdQuery query);
    Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query);
}