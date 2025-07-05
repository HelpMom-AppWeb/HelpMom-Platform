using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

public interface IDoctorCommandService
{
    public Task<Doctor?> Handle(CreateDoctorCommand command);
}