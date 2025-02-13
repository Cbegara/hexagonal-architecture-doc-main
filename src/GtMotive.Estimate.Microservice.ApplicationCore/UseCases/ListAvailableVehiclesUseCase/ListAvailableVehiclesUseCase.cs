using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase
{
    /// <summary>
    /// Use case for listing available vehicles.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPortStandard">The output port standard.</param>
    /// <param name="outputPortNotFound">The output port not found.</param>
    /// <param name="mapper">The mapper.</param>
    public sealed class ListAvailableVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IOutputPortStandard<ListAvailableVehiclesUseCaseOutput> outputPortStandard,
        IOutputPortNotFound outputPortNotFound,
        IMapper mapper) : IUseCase<ListAvailableVehiclesUseCaseInput>
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IOutputPortStandard<ListAvailableVehiclesUseCaseOutput> _outputPortStandard = outputPortStandard ?? throw new ArgumentNullException(nameof(outputPortStandard));
        private readonly IOutputPortNotFound _outputPortNotFound = outputPortNotFound ?? throw new ArgumentNullException(nameof(outputPortNotFound));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Executes the use case to list available vehicles.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ListAvailableVehiclesUseCaseInput input)
        {
            try
            {
                var availableVehicles = await _vehicleRepository.GetAvailableVehiclesAsync();
                var availableVehiclesDto = _mapper.Map<IEnumerable<VehicleDto>>(availableVehicles);

                var output = new ListAvailableVehiclesUseCaseOutput(availableVehiclesDto);

                if (output.AvailableVehicles.Count == 0)
                {
                    _outputPortNotFound.NotFoundHandle("There aren´t avaible vehicles at this moment.");
                }
                else
                {
                    _outputPortStandard.StandardHandle(output);
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
