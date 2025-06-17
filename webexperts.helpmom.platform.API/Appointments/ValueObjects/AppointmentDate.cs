namespace webexperts.helpmom.platform.Appointments.Domain.Model.ValueObjects;

public class AppointmentDate
{
    public DateTime Date { get; }
    public TimeSpan Time { get; }

    public AppointmentDate(DateTime date, TimeSpan time)
    {
        if (date < DateTime.Today)
            throw new ArgumentException("La fecha no puede ser en el pasado");

        Date = date.Date;
        Time = time;
    }

    protected IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return Time;
    }
}

