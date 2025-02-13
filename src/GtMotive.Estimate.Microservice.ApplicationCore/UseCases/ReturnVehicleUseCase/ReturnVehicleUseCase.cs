using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase
{
    /// <summary>
    /// Use case for returning a vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="outputPortNotFound">The output port for not found cases.</param>
    /// <param name="mapper">The mapper.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public sealed class ReturnVehicleUseCase(IRentalRepository rentalRepository,
        IVehicleRepository vehicleRepository,
        IOutputPortStandard<ReturnVehicleUseCaseOutput> outputPort,
        IOutputPortNotFound outputPortNotFound,
        IMapper mapper) : IUseCase<ReturnVehicleUseCaseInput>
    {
        private readonly IRentalRepository _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IOutputPortStandard<ReturnVehicleUseCaseOutput> _outputPortStandard = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        private readonly IOutputPortNotFound _outputPortNotFound = outputPortNotFound ?? throw new ArgumentNullException(nameof(outputPortNotFound));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input data for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ReturnVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                var rental = await _rentalRepository.GetByIdAsync(input.RentalId);
                if (rental != null)
                {
                    rental.ReturnVehicle();
                    await _rentalRepository.CompleteRentalAsync(rental.RentalId, rental.EndDate.GetValueOrDefault());

                    var vehicle = await _vehicleRepository.GetByIdAsync(rental.VehicleId);
                    vehicle.IsAvailable = true;
                    await _vehicleRepository.UpdateAsync(vehicle.VehicleId, vehicle);

                    var output = _mapper.Map<ReturnVehicleUseCaseOutput>(rental);
                    _outputPortStandard.StandardHandle(output);
                }
                else
                {
                    throw new InvalidOperationException("Rental not found or already returned.");
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                _outputPortNotFound.NotFoundHandle(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _outputPortNotFound.NotFoundHandle("An unexpected error occurred: " + ex.Message);
                throw;
            }
        }
    }
}
