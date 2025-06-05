using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Queries;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;
using webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;
using webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Transform;


namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Health Data")]

public class HealthDataController(IHealthDataCommandService healthDataCommandService, IHealthDataQueryService healthDataQueryService) : ControllerBase
{
    //OBTENER HEALTH DATA POR ID PROPIO
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets health data source by id",
        Description = "Gets heath data for a given identifier.",
        OperationId = "GetHealthDataById")]
    [SwaggerResponse(200, "The health data was found", typeof(HealthDataResource))]
    public async Task<ActionResult> GetHealthDataById(int id)
    {
        var getHealthDataByIdQuery = new GetHealthDataByIdQuery(id);
        var result = await healthDataQueryService.Handle(getHealthDataByIdQuery);
        if(result == null) return NotFound();
        var resource = HealthDataResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    //CREAR HEALTH DATA
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a health data source",
        Description = "Creates a health data with a given patient ID",
        OperationId = "CreateHealthData")]
    [SwaggerResponse(201, "The Health Data was created", typeof(HealthDataResource))]
    [SwaggerResponse(400, "The Health Data was not created")]
    public async Task<ActionResult> CreateHealthData([FromBody] CreateHealthDataResource resource)
    {
        var createHealthDataCommand = CreateHealthDataSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await healthDataCommandService.Handle(createHealthDataCommand);
        if(result == null) return BadRequest();
        var healthResource = HealthDataResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetHealthDataById), new { id = result.Id }, HealthDataResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    //OBTENER TODOS LOS HEALTH DATA
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all health data sources",
        Description = "Gets all health data sources",
        OperationId = "GetAllHealthData")]
    [SwaggerResponse(200, "The health data was found", typeof(IEnumerable<HealthDataResource>))]
    public async Task<ActionResult> GetAllHealthData()
    {
        var getAllHealthDataQuery = new GetAllHealthDataQuery();
        var healthData = await healthDataQueryService.Handle(getAllHealthDataQuery);
        var resources = healthData.Select(HealthDataResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    //OBTENER TODOS LOS HEALTH DATA POR PACIENTE
    private async Task<ActionResult> GetHealthDataByPatientId(int patientId)
    {
        var getHealthDataByPatientIdQuery = new GetHealthDataByPatientIdQuery(patientId);
        var healthData = await healthDataQueryService.Handle(getHealthDataByPatientIdQuery);
        var resources = healthData.Select(HealthDataResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("patientId")]
    public async Task<ActionResult> GetHealthDataFromQuery([FromQuery] int patientId)
    {
        return await GetHealthDataByPatientId(patientId);
    }
    
    
    

}