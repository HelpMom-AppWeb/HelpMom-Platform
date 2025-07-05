using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;
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
    public async Task<IActionResult> GetPatientsByDoctor(
        [FromRoute] int doctorId)
    {
        var getAllPatientsByAssignedDoctorIdQuery = new GetAllPatientsByAssignedDoctorIdQuery(doctorId);
        var patients = await patientQueryService.Handle(getAllPatientsByAssignedDoctorIdQuery);
        var patientResources = patients.Select(PatientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(patientResources);
    }
}