using webexperts.helpmom.platform.API.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.Domain.Services;

public interface IMedicationQueryService
{
    Task<Medication?> Handle(GetMedicationByIdQuery query);
    Task<IEnumerable<Medication>> Handle(GetAllMedicationsQuery query);
    Task<IEnumerable<Medication>> Handle(GetMedicationsByPrescriptionIdQuery query);
    Task<bool> Handle(CheckMedicationExistsInPrescriptionQuery query);
}