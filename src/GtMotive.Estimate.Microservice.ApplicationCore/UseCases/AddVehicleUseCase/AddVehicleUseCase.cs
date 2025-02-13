using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase
{
    /// <summary>
    /// Use case for adding a vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AddVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPortStandard">The standard output port.</param>
    /// <param name="outputPortNotFound">The not found output port.</param>
    /// <param name="mapper">The mapper instance used for object mapping.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public sealed class AddVehicleUseCase(
    IVehicleRepository vehicleRepository,
    IOutputPortStandard<AddVehicleUseCaseOutput> outputPortStandard,
    IOutputPortNotFound outputPortNotFound,
    IMapper mapper) : IUseCase<AddVehicleUseCaseInput>
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IOutputPortStandard<AddVehicleUseCaseOutput> _outputPortStandard = outputPortStandard ?? throw new ArgumentNullException(nameof(outputPortStandard));
        private readonly IOutputPortNotFound _outputPortNotFound = outputPortNotFound ?? throw new ArgumentNullException(nameof(outputPortNotFound));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Executes the use case with the specified input.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(AddVehicleUseCaseInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                var vehicle = _mapper.Map<Vehicle>(input);
                if (IsVehicleValid(vehicle))
                {
                    await _vehicleRepository.AddAsync(vehicle);

                    var output = _mapper.Map<AddVehicleUseCaseOutput>(vehicle);
                    _outputPortStandard.StandardHandle(output);
                }
                else
                {
                    throw new InvalidOperationException("The vehicle cannot be older than 5 years and the manufacturing date cannot be later than the current date.\r\n");
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

        /// <summary>
        /// Validates if the vehicle is not older than 5 years.
        /// </summary>
        /// <param name="vehicle">The vehicle to validate.</param>
        /// <returns>True if the vehicle is not older than 5 years, otherwise false.</returns>
        private static bool IsVehicleValid(Vehicle vehicle)
        {
            return (DateTime.Now.Year - vehicle.YearOfManufacture) <= 5 && (DateTime.Now.Year >= vehicle.YearOfManufacture);
        }
    }
}
