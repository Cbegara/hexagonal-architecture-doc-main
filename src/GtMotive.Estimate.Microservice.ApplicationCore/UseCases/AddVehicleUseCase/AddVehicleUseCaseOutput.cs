using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase
{
    /// <summary>
    /// Output data for the AddVehicle use case.
    /// </summary>
    public sealed class AddVehicleUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the unique identifier of the vehicle.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the use case output.
        /// </summary>
        public string Message { get; set; }
    }
}
