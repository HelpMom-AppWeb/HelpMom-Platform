using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Chat.Domain.Repositories;
using webexperts.helpmom.platform.API.Chat.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.Chat.Application.Internal.CommandServices;

public class CreateMessageCommandService(
    IMessageRepository messageRepository,
    MessageDomainService domainService,
    IUnitOfWork unitOfWork) 
{
    public async Task<Message?> Handle(CreateMessageCommand command)
    {
        var message = new Message(
            command.Text,
            command.Timestamp,
            command.From,
            command.PatientId
        );

        if (!domainService.IsValid(message))
            return null;

        await messageRepository.AddAsync(message);
        await unitOfWork.CompleteAsync();

        return message;
    }
}