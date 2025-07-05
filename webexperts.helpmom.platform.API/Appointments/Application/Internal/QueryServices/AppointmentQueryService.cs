
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Queries;
using webexperts.helpmom.platform.API.Appointments.Domain.Repositories;
using webexperts.helpmom.platform.API.Appointments.Domain.Services;

namespace webexperts.helpmom.platform.API.Appointments.Application.Internal.QueryServices;

public class AppointmentQueryService(IAppointmentRepository appointmentRepository) : IAppointmentQueryService
{
    public async Task<Appointment?> Handle(GetAppointmentByIdQuery query)
    {
        return await appointmentRepository.FindByIdAsync(query.AppointmentId);
    }

    public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentQuery query)
    {
        return await appointmentRepository.ListAsync();
    }

    public async Task<IEnumerable<Appointment>> Handle(GetAppointmentByDoctorId query)
    {
        return await appointmentRepository.FindByPatientIdAsync(query.DoctorId);
    }

    public async Task<IEnumerable<Appointment>> Handle(GetAppointmentByPatientId query)
    {
        return await appointmentRepository.FindByPatientIdAsync(query.PatientId);
    }
}