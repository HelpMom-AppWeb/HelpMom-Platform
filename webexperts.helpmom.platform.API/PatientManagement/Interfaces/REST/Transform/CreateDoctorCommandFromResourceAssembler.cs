using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

public static class CreateDoctorCommandFromResourceAssembler
{
    public static CreateDoctorCommand ToCommandFromResource(CreateDoctorResource resource)
    {
        return new CreateDoctorCommand(
            resource.ProfileId);
    }
}