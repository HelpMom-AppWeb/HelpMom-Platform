using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Commands;

namespace webexperts.helpmom.platform.API.Appointments.Domain.Services;

public interface IAppointmentCommandService
{
    Task<Appointment?> Handle(CreateAppointmentCommand command);
}