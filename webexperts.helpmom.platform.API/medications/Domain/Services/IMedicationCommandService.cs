using webexperts.helpmom.platform.API.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Domain.Model.Entities;

namespace webexperts.helpmom.platform.API.Domain.Services;


public interface IMedicationCommandService
{
    Task<Medication?> Handle(CreateMedicationCommand command);
    Task<bool> Handle(DeleteMedicationCommand command);
}