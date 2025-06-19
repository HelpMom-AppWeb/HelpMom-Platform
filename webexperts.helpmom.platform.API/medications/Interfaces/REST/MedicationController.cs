using System.Net.Mime;
                    using Microsoft.AspNetCore.Mvc;
                    using Swashbuckle.AspNetCore.Annotations;
                    using webexperts.helpmom.platform.API.Domain.Model.Commands;
                    using webexperts.helpmom.platform.API.Domain.Model.Queries;
                    using webexperts.helpmom.platform.API.Domain.Services;
                    using webexperts.helpmom.platform.API.Interfaces.REST.Resources;
                    using webexperts.helpmom.platform.API.Interfaces.REST.Transform;
                    
                    namespace webexperts.helpmom.platform.API.Interfaces.REST;
                    
                    [ApiController]
                    [Route("api/v1/[controller]")]
                    [Produces(MediaTypeNames.Application.Json)]
                    [SwaggerTag("Medications")]
                    public class MedicationController : ControllerBase
                    {
                        private readonly IMedicationCommandService _medicationCommandService;
                        private readonly IMedicationQueryService _medicationQueryService;
                        private readonly IPrescriptionQueryService _prescriptionQueryService;
                    
                        public MedicationController(
                            IMedicationCommandService medicationCommandService,
                            IMedicationQueryService medicationQueryService,
                            IPrescriptionQueryService prescriptionQueryService)
                        {
                            this._medicationCommandService = medicationCommandService;
                            this._medicationQueryService = medicationQueryService;
                            this._prescriptionQueryService = prescriptionQueryService;
                        }
                    
                        [HttpGet("{id}")]
                        [SwaggerOperation(
                            Summary = "Gets medication by id",
                            Description = "Gets medication for a given identifier.",
                            OperationId = "GetMedicationById")]
                        [SwaggerResponse(200, "The medication was found", typeof(MedicationResource))]
                        [SwaggerResponse(404, "The medication was not found")]
                        public async Task<ActionResult> GetMedicationById(int id)
                        {
                            var getMedicationByIdQuery = new GetMedicationByIdQuery(id);
                            var result = await _medicationQueryService.Handle(getMedicationByIdQuery);
                            if (result == null) return NotFound();
                            var resource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(result);
                            return Ok(resource);
                        }
                    
                        [HttpGet]
                        [SwaggerOperation(
                            Summary = "Gets all medications",
                            Description = "Gets all medications in the system",
                            OperationId = "GetAllMedications")]
                        [SwaggerResponse(200, "The medications were found", typeof(IEnumerable<MedicationResource>))]
                        public async Task<ActionResult> GetAllMedications()
                        {
                            var getAllMedicationsQuery = new GetAllMedicationsQuery();
                            var medications = await _medicationQueryService.Handle(getAllMedicationsQuery);
                            var resources = medications.Select(MedicationResourceFromEntityAssembler.ToResourceFromEntity);
                            return Ok(resources);
                        }
                    
                        [HttpGet("prescription/{prescriptionId}")]
                        [SwaggerOperation(
                            Summary = "Gets medications by prescription id",
                            Description = "Gets all medications for a given prescription identifier.",
                            OperationId = "GetMedicationsByPrescriptionId")]
                        [SwaggerResponse(200, "The medications were found", typeof(IEnumerable<MedicationResource>))]
                        [SwaggerResponse(404, "The prescription was not found")]
                        public async Task<ActionResult> GetMedicationsByPrescriptionId(Guid prescriptionId)
                        {
                            var prescriptionExistsQuery = new GetPrescriptionByIdQuery(prescriptionId);
                            var prescription = await _prescriptionQueryService.Handle(prescriptionExistsQuery);
                            if (prescription == null)
                                return NotFound(new { message = "Receta médica no encontrada." });
                    
                            var getMedicationsByPrescriptionIdQuery = new GetMedicationsByPrescriptionIdQuery(prescriptionId);
                            var medications = await _medicationQueryService.Handle(getMedicationsByPrescriptionIdQuery);
                            var resources = medications.Select(MedicationResourceFromEntityAssembler.ToResourceFromEntity);
                            return Ok(resources);
                        }
                    
                        [HttpPost]
                        [SwaggerOperation(
                            Summary = "Creates a new medication",
                            Description = "Creates a new medication in the system",
                            OperationId = "CreateMedication")]
                        [SwaggerResponse(201, "The medication was created successfully", typeof(MedicationResource))]
                        [SwaggerResponse(400, "Invalid input data")]
                        public async Task<ActionResult> CreateMedication([FromBody] CreateMedicationCommand command)
                        {
                            if (!ModelState.IsValid)
                                return BadRequest(ModelState);
                    
                            var result = await _medicationCommandService.Handle(command);
                            var resource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(result);
                            return CreatedAtAction(nameof(GetMedicationById), new { id = resource.Id }, resource);
                        }
                    }