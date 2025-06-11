using webexperts.helpmom.platform.Appointments.Domain.Model.Commands;
using webexperts.helpmom.platform.Appointments.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.Appointments.Domain.Model.Aggregates;

public class Appointments
{
    public  string Description { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}