using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Queries;
using webexperts.helpmom.platform.API.Appointments.Domain.Repositories;
using webexperts.helpmom.platform.API.Appointments.Domain.Services;
using webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Resources;
using webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Transform;

namespace webexperts.helpmom.platform.API.Appointments.Interfaces.REST;



[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Appointment")]

public class AppointmentController(IAppointmentCommandService appointmentCommandService, IAppointmentQueryService appointmentQueryService) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets appointment source by id",
        Description = "Gets appointment for a given identifier.",
        OperationId = "GetAppointmentById")]
    [SwaggerResponse(200, "The appointment was found", typeof(AppointmentResource))]
    public async Task<ActionResult> GetAppointmentById(int id)
    {
        var getAppointmentByIdQuery = new GetAppointmentByIdQuery(id);
        var result = await appointmentQueryService.Handle(getAppointmentByIdQuery);
        if(result == null) return NotFound();
        var resource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all appointment sources",
        Description = "Gets all appointment sources",
        OperationId = "GetAllAppointment")]
    [SwaggerResponse(200, "The appointment was found", typeof(IEnumerable<AppointmentResource>))]
    public async Task<ActionResult> GetAllAppointment()
    {
        var getAllAppointmentQuery = new GetAllAppointmentQuery();
        var appointments = await appointmentQueryService.Handle(getAllAppointmentQuery);
        var resources = appointments.Select(AppointmentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates an appointment data source",
        Description = "Creates an appointment data with a given patient ID",
        OperationId = "CreateAppointment")]
    [SwaggerResponse(201, "The appointment was created", typeof(AppointmentResource))]
    [SwaggerResponse(400, "The appointment was not created")]
    public async Task<ActionResult> CreateAppointment([FromBody] CreateAppointmentResource resource)
    {
        var createAppointmentCommand = CreateAppointmentSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await appointmentCommandService.Handle(createAppointmentCommand);
        if(result == null) return BadRequest();
        var appointmentResource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetAppointmentById), new { id = result.Id }, AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}