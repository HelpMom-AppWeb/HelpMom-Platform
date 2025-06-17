using Microsoft.AspNetCore.Mvc;
using webexperts.helpmom.platform.Chat.Application.Internal.CommandServices;
using webexperts.helpmom.platform.Chat.Application.Internal.QueryServices;
using webexperts.helpmom.platform.Chat.Interfaces.REST.Resources;
using webexperts.helpmom.platform.Chat.Domain.Model.Commands;
using webexperts.helpmom.platform.Chat.Domain.Model.ValueObjects;
using webexperts.helpmom.platform.Chat.Interfaces.REST.Transform;

namespace webexperts.helpmom.platform.Chat.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly CreateMessageCommandService _commandService;
    private readonly GetMessagesByPatientIdQueryService _queryService;

    public ChatController(CreateMessageCommandService commandService, GetMessagesByPatientIdQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet("messages/{patientId}")]
    public async Task<IActionResult> GetMessagesByPatientId(int patientId)
    {
        var messages = await _queryService.Handle(new GetMessagesByPatientIdQuery(patientId));
        var resources = messages.Select(MessageMapper.ToResource);
        return Ok(resources);
    }

    [HttpPost("messages")]
    public async Task<IActionResult> CreateMessage([FromBody] MessageResource resource)
    {
        var from = new From(resource.FromUserId, resource.FromRole);

        var command = new CreateMessageCommand(
            resource.Text,
            resource.Timestamp,
            from,
            resource.PatientId
        );

        var result = await _commandService.Handle(command);
        var resultResource = MessageMapper.ToResource(result!);
        return CreatedAtAction(nameof(GetMessagesByPatientId), new { patientId = result.patientId }, resultResource);
    }
}