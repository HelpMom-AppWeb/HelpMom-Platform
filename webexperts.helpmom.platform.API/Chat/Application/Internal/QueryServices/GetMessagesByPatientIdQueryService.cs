using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Queries;
using webexperts.helpmom.platform.API.Chat.Domain.Repositories;

namespace webexperts.helpmom.platform.API.Chat.Application.Internal.QueryServices;


public class GetMessagesByPatientIdQueryService(IMessageRepository messageRepository)
{

    public async Task<IEnumerable<Message>> Handle(GetMessagesByPatientIdQuery query)
    {
        return await messageRepository.ListByPatientIdAsync(query.PatientId);
    }
}