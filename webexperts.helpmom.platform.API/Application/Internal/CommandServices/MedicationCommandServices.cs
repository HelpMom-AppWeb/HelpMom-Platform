using webexperts.helpmom.platform.API.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Domain.Repositories;
using webexperts.helpmom.platform.API.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.Application.Internal.CommandServices;

public class MedicationCommandServices (IMedicationRepository medicationRepository, IUnitOfWork unitOfWork) : IMedicationCommandService 
{
    public async Task<Medication?> Handle(CreateMedicationCommand command)
    {
       var medication = new Medication (command.Name, command.Concentration, command.Quantity, command.Dose, command.Via, command.Frequency, command.Duration, command.PrescriptionId, command.Presentation, command.Manufacturer);

        await medicationRepository.AddAsync(medication);
        await unitOfWork.CompleteAsync();

        return medication;
    }

    public Task<bool> Handle(DeleteMedicationCommand command)
    {
        throw new NotImplementedException();
    }
}