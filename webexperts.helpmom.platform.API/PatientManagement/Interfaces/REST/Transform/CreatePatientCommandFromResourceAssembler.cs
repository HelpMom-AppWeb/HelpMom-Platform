using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

public static class CreatePatientCommandFromResourceAssembler
{
    public static CreatePatientCommand ToCommandFromResource(
        CreatePatientResource resource)
    {
        return new CreatePatientCommand(
            resource.ProfileId,
            resource.Phone,
            resource.AssignedDoctorId,
            resource.BabyName,
            resource.DateOfBirth,
            resource.BabyGender);
    }
}