using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Queries;
using webexperts.helpmom.platform.API.Chat.Domain.Repositories;

namespace webexperts.helpmom.platform.API.Chat.Application.Internal.QueryServices;


public class GetMessagesByPatientIdQueryService
{
    private readonly IMessageRepository _messageRepository;

    public GetMessagesByPatientIdQueryService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<Message>> Handle(GetMessagesByPatientIdQuery query)
    {
        return await _messageRepository.ListByPatientIdAsync(query.PatientId);
    }
}