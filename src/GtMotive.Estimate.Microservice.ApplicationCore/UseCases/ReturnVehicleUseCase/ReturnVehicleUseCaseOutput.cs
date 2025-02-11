using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase
{
    /// <summary>
    /// Output data for the ReturnVehicle use case.
    /// </summary>
    public sealed class ReturnVehicleUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the rental identifier.
        /// </summary>
        public Guid RentalId { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}
