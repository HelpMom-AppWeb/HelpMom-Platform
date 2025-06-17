using webexperts.helpmom.platform.API.Appointments.Application.Internal.QueryServices;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Transform;

public static class AppointmentResourceFromEntityAssembler
{
    public static AppointmentResource ToResourceFromEntity(Appointment entity)=>
        new AppointmentResource(entity.DoctorId, entity.DoctorName, entity.Date, entity.Time, entity.Description,
            entity.PatientId, entity.PatientName);
}