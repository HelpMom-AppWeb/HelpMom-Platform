using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

public static class DoctorResourceFromEntityAssembler
{
    public static DoctorResource ToResourceFromEntity(Doctor entity)
    {
        return new DoctorResource(entity.Id, entity.ProfileId.Id);
    }
}