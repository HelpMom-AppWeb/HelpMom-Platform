using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;


namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Health Data")]

public class HealthDataController(IHealthDataCommandService healthDataCommandService, IHealthDataQueryService healthDataQueryService) : ControllerBase
{
    
    
}