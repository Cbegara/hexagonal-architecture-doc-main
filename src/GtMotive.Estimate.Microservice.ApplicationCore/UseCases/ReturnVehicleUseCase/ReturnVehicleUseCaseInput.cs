using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase
{
    /// <summary>
    /// Input data for the ReturnVehicle use case.
    /// </summary>
    public sealed class ReturnVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the rental identifier.
        /// </summary>
        public Guid RentalId { get; set; }
    }
}
