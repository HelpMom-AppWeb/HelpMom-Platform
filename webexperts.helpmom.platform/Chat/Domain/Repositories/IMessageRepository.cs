using webexperts.helpmom.platform.Chat.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.Chat.Domain.Repositories;

public interface IMessageRepository
{
    Task<Message> CreateAsync(Message message);
    Task<IEnumerable<Message>> ListByPatientIdAsync(int patientId);
    Task DeleteAsync(int messageId);
}