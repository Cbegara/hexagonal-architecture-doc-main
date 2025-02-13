using System;
using System.Net.Http;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Controller for handling rental operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController(
        IUseCase<RentVehicleUseCaseInput> rentVehicleUseCase,
        IUseCase<ReturnVehicleUseCaseInput> returnVehicleUseCase,
        IUseCase<ListActiveRentalsUseCaseInput> activeRentalsUseCase,
        IWebApiPresenter webApiPresenter) : ControllerBase
    {
        private readonly IUseCase<RentVehicleUseCaseInput> _rentVehicleUseCase = rentVehicleUseCase ?? throw new ArgumentNullException(nameof(rentVehicleUseCase));
        private readonly IUseCase<ReturnVehicleUseCaseInput> _returnVehicleUseCase = returnVehicleUseCase ?? throw new ArgumentNullException(nameof(returnVehicleUseCase));
        private readonly IUseCase<ListActiveRentalsUseCaseInput> _activeRentalsUseCase = activeRentalsUseCase ?? throw new ArgumentNullException(nameof(activeRentalsUseCase));
        private readonly IWebApiPresenter _webApiPresenter = webApiPresenter ?? throw new ArgumentNullException(nameof(webApiPresenter));

        /// <summary>
        /// Creates a new rental.
        /// </summary>
        /// <param name="request">The rental request input.</param>
        /// <returns>Action result indicating the outcome of the operation.</returns>
        [HttpPut("rental")]
        public async Task<IActionResult> CreateRental([FromBody] RentVehicleUseCaseInput request)
        {
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                await _rentVehicleUseCase.Execute(request);
                return Ok("Rental created successfully.");
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
        /// Returns a rental.
        /// </summary>
        /// <param name="request">The return rental request input.</param>
        /// <returns>Action result indicating the outcome of the operation.</returns>
        [HttpPost("return")]
        public async Task<IActionResult> ReturnRental([FromBody] ReturnVehicleUseCaseInput request)
        {
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                await _returnVehicleUseCase.Execute(request);
                return Ok("Rental returned successfully.");
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
        /// Lists all active rentals.
        /// </summary>
        /// <returns>Action result containing the list of active rentals.</returns>
        [HttpGet("list")]
        public async Task<IActionResult> ListActiveRentals()
        {
            try
            {
                await _activeRentalsUseCase.Execute(new ListActiveRentalsUseCaseInput());
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
