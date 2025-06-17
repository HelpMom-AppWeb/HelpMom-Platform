public interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(string id);
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(string id);
    Task<bool> ExistsAsync(string id);
}