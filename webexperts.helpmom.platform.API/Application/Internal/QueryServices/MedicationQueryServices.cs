using webexperts.helpmom.platform.API.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Domain.Model.Queries;
using webexperts.helpmom.platform.API.Domain.Repositories;
using webexperts.helpmom.platform.API.Domain.Services;

namespace webexperts.helpmom.platform.API.Application.Internal.QueryServices;

public class MedicationQueryServices (IMedicationRepository medicationRepository) : IMedicationQueryService
{
    public Task<Medication?> Handle(GetMedicationByIdQuery query)
    {
        return medicationRepository.FindByIdAsync(query.Id);
    }

    public Task<IEnumerable<Medication>> Handle(GetAllMedicationsQuery query)
    {
        return medicationRepository.ListAsync();
    }

    public Task<IEnumerable<Medication>> Handle(GetMedicationsByPrescriptionIdQuery query)
    {
        return medicationRepository.FindByPrescriptionIdAsync(query.PrescriptionId);
    }

    public Task<bool> Handle(CheckMedicationExistsInPrescriptionQuery query)
    {
        return medicationRepository.ExistsInPrescriptionAsync(query.MedicationId, query.PrescriptionId);
    }
}