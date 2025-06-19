using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.Chat.Domain.Repositories;
using webexperts.helpmom.platform.Chat.Infraestructure.Persistence;

namespace webexperts.helpmom.platform.Chat.Infraestructure.Persistence.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ChatDbContext _context;

    public MessageRepository(ChatDbContext context)
    {
        _context = context;
    }

    public async Task<Message> CreateAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return message;
    }

    public async Task<IEnumerable<Message>> ListByPatientIdAsync(int patientId)
    {
        return await _context.Messages
            .Where(m => m.patientId == patientId)
            .ToListAsync();
    }

    public async Task DeleteAsync(int messageId)
    {
        var message = await _context.Messages.FindAsync(messageId);
        if (message != null)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}