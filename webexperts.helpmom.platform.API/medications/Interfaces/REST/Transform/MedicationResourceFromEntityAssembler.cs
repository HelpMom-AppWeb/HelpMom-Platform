using webexperts.helpmom.platform.API.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.Interfaces.REST.Transform;

public static class MedicationResourceFromEntityAssembler
{
    public static MedicationResource ToResourceFromEntity(Medication entity) =>
        new MedicationResource(
            entity.Id,
            entity.Name,
            entity.Presentation,
            entity.Manufacturer,
            entity.PrescriptionId
        );
}