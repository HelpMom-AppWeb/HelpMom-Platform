using webexperts.helpmom.platform.API.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.Domain.Repositories;

public interface IMedicationRepository : IBaseRepository<Medication>
{
    Task<IEnumerable<Medication>> FindByPrescriptionIdAsync(Guid prescriptionId);
    Task<Medication?> FindByNameAndPrescriptionIdAsync(string name, Guid prescriptionId);
    Task<bool> ExistsInPrescriptionAsync(string name, Guid prescriptionId);
}