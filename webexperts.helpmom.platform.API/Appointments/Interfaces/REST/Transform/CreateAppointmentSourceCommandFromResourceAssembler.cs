using webexperts.helpmom.platform.API.Appointments.Application.Internal.QueryServices;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Transform;

public class CreateAppointmentSourceCommandFromResourceAssembler
{
    public static CreateAppointmentCommand ToCommandFromResource(CreateAppointmentResource resource)=>
        new CreateAppointmentCommand(resource.DoctorId, resource.DoctorName, resource.Date, resource.Time, resource.Description,
            resource.PatientId, resource.PatientName);
}