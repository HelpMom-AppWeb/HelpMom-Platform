using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;
using webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Transform;

namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/doctors/{doctorId:int}/patients")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Doctors")]
public class DoctorPatientsController(
    IPatientQueryService patientQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a list of patients by its Assigned Doctor ID",
        Description = "Gets a list of patients by its given Assigned Doctor ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of patients found", typeof(IEnumerable<PatientResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "List of patients not found")]
    public async Task<IActionResult> GetPatientsByDoctorId(
        [FromRoute] int doctorId)
    {
        var getAllPatientsByAssignedDoctorIdQuery = new GetAllPatientsByAssignedDoctorIdQuery(doctorId);
        var patients = await patientQueryService.Handle(getAllPatientsByAssignedDoctorIdQuery);
        var patientResources = patients.Select(PatientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(patientResources);
    }
}