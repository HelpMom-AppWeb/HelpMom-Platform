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
[SwaggerTag("Available Doctor Endpoints")]
public class DoctorsController(IDoctorCommandService doctorCommandService,
    IDoctorQueryService doctorQueryService
    ) : ControllerBase
{
    [HttpGet("{doctorId:int}")]
    [SwaggerOperation(
        Summary = "Gets a doctor by its ID",
        Description = "Get a doctor by given doctor ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Doctor found", typeof(DoctorResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Doctor not found")]
    public async Task<IActionResult> GetDoctorById(int doctorId)
    {
        var getDoctorByIdQuery = new GetDoctorByIdQuery(doctorId);
        var doctor = await doctorQueryService.Handle(getDoctorByIdQuery);
        if (doctor is null) return NotFound();
        var resource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(doctor);
        return Ok(resource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new doctor",
        Description = "Creates a new doctor with the provided details.",
        OperationId = "CreateDoctor")]
    [SwaggerResponse(StatusCodes.Status201Created, "Doctor created successfully", typeof(DoctorResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid doctor data")]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorResource resource)
    {
        var createDoctorCommand = CreateDoctorCommandFromResourceAssembler.ToCommandFromResource(resource);
        var doctor = await doctorCommandService.Handle(createDoctorCommand);
        if (doctor is null) return BadRequest("Doctor could not be created.");
        var doctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(doctor);
        return CreatedAtAction(nameof(GetDoctorById), 
            new { doctorId = doctor.Id}, doctorResource);
    }
    
    [HttpGet] 
    [SwaggerOperation( 
        Summary = "Gets a list of all doctors",
        Description = "Get a list of all doctors")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of doctors found", typeof(IEnumerable<DoctorResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Doctors not found")]
    public async Task<IActionResult> GetAllDoctors()
    {
        var getAllDoctorsQuery = new GetAllDoctorsQuery();
        var doctors = await doctorQueryService.Handle(getAllDoctorsQuery);
        var doctorResources = doctors.Select(DoctorResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(doctorResources);
    }
}