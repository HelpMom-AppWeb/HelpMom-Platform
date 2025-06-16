using webexperts.helpmom.platform.Chat.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.Chat.Domain.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetMessagesByPatientIdAsync(int patientId);
    Task<Message> SaveAsync(Message message);
    Task DeleteAsync(int id);
}