using webexperts.helpmom.platform.API.Domain.Model.Entities;

namespace webexperts.helpmom.platform.API.Domain.Repositories;

public interface IMedicationRepository
{
    Task<IEnumerable<Medication>> FindByPrescriptionIdAsync(Guid prescriptionId);
    Task<Medication?> FindByNameAndPrescriptionIdAsync(string name, Guid prescriptionId);
    Task<bool> ExistsInPrescriptionAsync(string name, Guid prescriptionId);
}