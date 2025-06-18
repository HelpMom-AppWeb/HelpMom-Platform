using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Patient Endpoints")]
public class PatientsController(IPatientCommandService patientCommandService,
    IPatientQueryService patientQueryService
    ) : ControllerBase
{
    [HttpGet("{patientId:int}")]
    [SwaggerOperation(
        Summary = "Gets a patient by its ID",
        Description = "Get a patient by given patient ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Patient found", typeof(PatientResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Patient not found")]
    public async Task<IActionResult> GetPatientById(int patientId)
    {
        var getPatientByIdQuery = new GetPatientByIdQuery(patientId);
        var patient = await patientQueryService.Handle(getPatientByIdQuery);
        if (patient is null) return NotFound();
        var resource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return Ok(resource);
    }
    
    [HttpGet("{profileId:int}")]
    [SwaggerOperation(
        Summary = "Gets a patient by its profile ID",
        Description = "Get a patient by given profile ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Patient found", typeof(PatientResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Patient not found")]
    public async Task<IActionResult> GetPatientByProfileId(int profileId)
    {
        var getPatientByProfileIdQuery = new GetPatientByProfileIdQuery(profileId);
        var patient = await patientQueryService.Handle(getPatientByProfileIdQuery);
        if (patient is null) return NotFound();
        var resource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return Ok(resource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new patient",
        Description = "Creates a new patient with the provided details.",
        OperationId = "CreatePatient")]
    [SwaggerResponse(StatusCodes.Status201Created, "Patient created successfully", typeof(PatientResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid patient data")]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientResource resource)
    {
        var createPatientCommand = CreatePatientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var patient = await patientCommandService.Handle(createPatientCommand);
        if (patient is null) return BadRequest("Patient could not be created.");
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return CreatedAtAction(nameof(GetPatientById), 
            new { patientId = patient.Id}, patientResource);
    }
}