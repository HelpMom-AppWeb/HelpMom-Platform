using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Appointments.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class AppointmentRepository(AppDbContext context) : 
    BaseRepository<Appointment>(context), IAppointmentRepository
{
    public async Task<IEnumerable<Appointment>> FindByPatientIdAsync(int patientId)
    {
        return await Context.Set<Appointment>().Where(h => h.PatientId == patientId).ToListAsync();
    }
}