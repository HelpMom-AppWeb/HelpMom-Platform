using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Repositories;
using webexperts.helpmom.platform.API.Chat.Infraestructure.Persistence;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.Chat.Infraestructure.Persistence.Repositories;

public class MessageRepository(AppDbContext context) : BaseRepository<Message>(context), IMessageRepository
{
    public async Task<IEnumerable<Message>> ListByPatientIdAsync(int patientId)
    {
        return await Context.Set<Message>()
                    .Where(m => m.PatientId == patientId)
                    .ToListAsync();
    }
    
}