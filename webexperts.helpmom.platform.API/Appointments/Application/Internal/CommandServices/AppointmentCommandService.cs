using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Appointments.Domain.Repositories;
using webexperts.helpmom.platform.API.Appointments.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.Appointments.Application.Internal.CommandServices;

public class AppointmentCommandService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    : IAppointmentCommandService
{
    public async Task<Appointment?> Handle(CreateAppointmentCommand command)
    {
        var appointment = new Appointment(
            command.DoctorId,
            command.DoctorName,
            command.Date,
            command.Time,
            command.Description,
            command.PatientId,
            command.PatientName
        );
        await appointmentRepository.AddAsync(appointment);
        await unitOfWork.CompleteAsync();
        return appointment;
    }
}