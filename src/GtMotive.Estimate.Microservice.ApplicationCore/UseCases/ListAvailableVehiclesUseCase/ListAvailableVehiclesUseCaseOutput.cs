using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase
{
    /// <summary>
    /// Output class for the ListAvailableVehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesUseCaseOutput(IEnumerable<VehicleDto> availableVehicles) : IUseCaseOutput
    {
        private readonly List<VehicleDto> _availableVehicles = availableVehicles.ToList();

        /// <summary>
        /// Gets the collection of available vehicles.
        /// </summary>
        public IReadOnlyCollection<VehicleDto> AvailableVehicles => _availableVehicles.AsReadOnly();
    }
}
