using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase
{
    /// <summary>
    /// Represents the input data required to rent a vehicle.
    /// </summary>
    public sealed class RentVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the vehicle.
        /// </summary>
        public Guid VehicleId { get; set; }
    }
}
