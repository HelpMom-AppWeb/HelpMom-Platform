using webexperts.helpmom.platform.Appointments.Application.Commands;
using webexperts.helpmom.platform.Appointments.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.Appointments.Interfaces.REST.Transform;

public class CreateAppointmentAssembler
{
    public static CreateAppointmentDataCommand ToCommand(CreateAppointmentResource resource)
    {
        return new CreateAppointmentDataCommand
        {
            DoctorId = resource.DoctorId,
            DoctorName = resource.DoctorName,
            Specialty = resource.Specialty,
            Date = resource.Date,
            Time = resource.Time,
            Description = resource.Description,
            PatientId = resource.PatientId,
            PatientName = resource.PatientName
        };
    }
}