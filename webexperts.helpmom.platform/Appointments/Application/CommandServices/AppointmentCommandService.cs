using webexperts.helpmom.platform.Appointments.Application.Commands;
using webexperts.helpmom.platform.Appointments.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.Appointments.Application;

public class AppointmentCommandService 
{
    private readonly IAppointmentRepository _repository;

    public AppointmentCommandService(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Appointment> Handle(CreateAppointmentDataCommand command)
    {
        var appointment = Appointment.Create(
            command.DoctorId,
            command.DoctorName,
            command.Date,
            command.Time,
            command.Description,
            command.PatientId,
            command.PatientName);

        await _repository.AddAsync(appointment);
        return appointment;
    }
}