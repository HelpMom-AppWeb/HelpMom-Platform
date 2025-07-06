using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

public static class BabyResourceFromEntityAssembler
{
    public static BabyResource ToResourceFromEntity(Baby entity)
    {
        return new BabyResource(
            entity.Name,
            entity.DateOfBirth,
            entity.Gender.ToString());
    }
}