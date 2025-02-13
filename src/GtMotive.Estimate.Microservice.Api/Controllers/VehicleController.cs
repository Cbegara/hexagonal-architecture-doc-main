using System;
using System.Net.Http;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Controller for managing vehicle-related operations.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="VehicleController"/> class.
    /// </remarks>
    /// <param name="addVehicleUseCase">The use case for adding a vehicle.</param>
    /// <param name="listAvailableVehiclesUseCase">The use case for listing available vehicles.</param>
    /// <param name="webApiPresenter">The presenter for web API responses.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(
        IUseCase<AddVehicleUseCaseInput> addVehicleUseCase,
        IUseCase<ListAvailableVehiclesUseCaseInput> listAvailableVehiclesUseCase,
        IWebApiPresenter webApiPresenter) : ControllerBase
    {
        private readonly IUseCase<AddVehicleUseCaseInput> _addVehicleUseCase = addVehicleUseCase ?? throw new ArgumentNullException(nameof(addVehicleUseCase));
        private readonly IUseCase<ListAvailableVehiclesUseCaseInput> _listAvailableVehiclesUseCase = listAvailableVehiclesUseCase ?? throw new ArgumentNullException(nameof(listAvailableVehiclesUseCase));
        private readonly IWebApiPresenter _webApiPresenter = webApiPresenter ?? throw new ArgumentNullException(nameof(webApiPresenter));

        /// <summary>
        /// Adds a new vehicle to the system.
        /// </summary>
        /// <param name="request">The vehicle details to add.</param>
        /// <returns>Action result indicating the outcome of the operation.</returns>
        [HttpPut("addVehicle")]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleUseCaseInput request)
        {
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                await _addVehicleUseCase.Execute(request);
                return Ok("Vehicle added successfully.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Service unavailable: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Invalid argument: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Operation error: {ex.Message}");
            }
        }

        /// <summary>
        /// Lists all available vehicles.
        /// </summary>
        /// <returns>Action result indicating the outcome of the operation.</returns>
        [HttpGet("available")]
        public async Task<IActionResult> ListAvailableVehicles()
        {
            try
            {
                await _listAvailableVehiclesUseCase.Execute(new ListAvailableVehiclesUseCaseInput());
                return _webApiPresenter.ActionResult ?? throw new InvalidOperationException();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Service unavailable: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Invalid argument: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Operation error: {ex.Message}");
            }
        }
    }
}
