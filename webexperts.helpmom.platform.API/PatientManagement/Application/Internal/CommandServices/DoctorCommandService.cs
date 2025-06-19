using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Application.Internal.CommandServices;

public class DoctorCommandService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    : IDoctorCommandService
{
    public async Task<Doctor?> Handle(CreateDoctorCommand command)
    {
        var doctor = new Doctor(command);
        await doctorRepository.AddAsync(doctor);
        await unitOfWork.CompleteAsync();
        return doctor;
    }
}