using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

public static class PatientResourceFromEntityAssembler
{
    public static PatientResource ToResourceFromEntity(Patient entity)
    {
        return new PatientResource(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.Phone,
            BabyResourceFromEntityAssembler.ToResourceFromEntity(entity.Baby),
            entity.AssignedDoctorId);
    }
}