using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Chat.Domain.Repositories;
using webexperts.helpmom.platform.API.Chat.Domain.Services;

namespace webexperts.helpmom.platform.API.Chat.Application.Internal.CommandServices;

public class CreateMessageCommandService
{
    private readonly IMessageRepository _messageRepository;
    private readonly MessageDomainService _domainService;

    public CreateMessageCommandService(IMessageRepository messageRepository, MessageDomainService domainService)
    {
        _messageRepository = messageRepository;
        _domainService = domainService;
    }

    public async Task<Message?> Handle(CreateMessageCommand command)
    {
        var message = new Message(
            command.Text,
            command.Timestamp,
            command.From,
            command.PatientId
        );

        if (!_domainService.IsValid(message))
            return null;

        return await _messageRepository.CreateAsync(message);
    }
}