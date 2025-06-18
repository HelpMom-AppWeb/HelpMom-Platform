using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.Appointments.Domain.Services;

public interface IAppointmentQueryService
{
    Task<Appointment?> Handle(GetAppointmentByIdQuery query);
    Task<IEnumerable<Appointment>> Handle(GetAllAppointmentQuery query);
    Task<IEnumerable<Appointment>> Handle(GetAppointmentByDoctorId query);
    Task<IEnumerable<Appointment>> Handle(GetAppointmentByPatientId query);
}