using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Application.Internal.CommandServices;

public class PatientCommandService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    : IPatientCommandService
{
    public async Task<Patient?> Handle(CreatePatientCommand command)
    {
        var patient = new Patient(command);
        await patientRepository.AddAsync(patient);
        await unitOfWork.CompleteAsync();
        return patient;
    }
}