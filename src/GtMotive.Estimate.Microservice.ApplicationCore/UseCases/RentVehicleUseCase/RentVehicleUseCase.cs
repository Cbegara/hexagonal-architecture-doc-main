using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase
{
    /// <summary>
    /// Use case for renting a vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="outputPortNotFound">The output port for not found scenarios.</param>
    /// <param name="mapper">The mapper.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public sealed class RentVehicleUseCase(IRentalRepository rentalRepository,
        IVehicleRepository vehicleRepository,
        IOutputPortStandard<RentVehicleUseCaseOutput> outputPort,
        IOutputPortNotFound outputPortNotFound,
        IMapper mapper) : IUseCase<RentVehicleUseCaseInput>
    {
        private readonly IRentalRepository _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IOutputPortStandard<RentVehicleUseCaseOutput> _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        private readonly IOutputPortNotFound _outputPortNotFound = outputPortNotFound ?? throw new ArgumentNullException(nameof(outputPortNotFound));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Executes the use case to rent a vehicle.
        /// </summary>
        /// <param name="input">The input data for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(RentVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                if (await HasActiveReservationAsync(input.CustomerName))
                {
                    throw new InvalidOperationException("The customer already has an active reservation.");
                }
                else
                {
                    var vehicle = await _vehicleRepository.GetByIdAsync(input.VehicleId);
                    if (vehicle is not null && vehicle.IsAvailable)
                    {
                        var rental = _mapper.Map<Rental>(input);
                        await _rentalRepository.AddAsync(rental);
                        vehicle.IsAvailable = false;
                        await _vehicleRepository.UpdateAsync(vehicle.VehicleId, vehicle);

                        var output = _mapper.Map<RentVehicleUseCaseOutput>(rental);
                        _outputPort.StandardHandle(output);
                    }
                    else
                    {
                        throw new InvalidOperationException("Vehicle is not available for rent.");
                    }
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

        private async Task<bool> HasActiveReservationAsync(string customerName)
        {
            return await _rentalRepository.HasActiveRentalAsync(customerName);
        }
    }
}
