using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webexperts.helpmom.platform.API.Chat.Application.Internal.CommandServices;
using webexperts.helpmom.platform.API.Chat.Application.Internal.QueryServices;
using webexperts.helpmom.platform.API.Chat.Interfaces.REST.Resources;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Chat.Domain.Model.ValueObjects;
using webexperts.helpmom.platform.API.Chat.Interfaces.REST.Transform;

namespace webexperts.helpmom.platform.API.Chat.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]/messages")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Doctor Endpoints")]
public class ChatController(
    CreateMessageCommandService commandService, 
    GetMessagesByPatientIdQueryService queryService) 
    : ControllerBase
{

    [HttpGet("{patientId:int}")]
    [SwaggerOperation(
        Summary = "Gets a list of messages by its patient ID",
        Description = "Get a list of messages by given patient ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Messages found", typeof(IEnumerable<MessageResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Messages not found")]
    public async Task<IActionResult> GetMessagesByPatientId(int patientId)
    {
        var messages = await queryService.Handle(new GetMessagesByPatientIdQuery(patientId));
        var resources = messages.Select(MessageMapper.ToResource);
        return Ok(resources);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMessage([FromBody] MessageResource resource)
    {
        var from = new From(resource.FromUserId, resource.FromRole);

        var command = new CreateMessageCommand(
            resource.Text,
            resource.Timestamp,
            from,
            resource.PatientId
        );

        var result = await commandService.Handle(command);
        if (result is null) return BadRequest("Message could not be created.");
        var resultResource = MessageMapper.ToResource(result);
        return CreatedAtAction(nameof(GetMessagesByPatientId), new { patientId = result.PatientId }, resultResource);
    }
}