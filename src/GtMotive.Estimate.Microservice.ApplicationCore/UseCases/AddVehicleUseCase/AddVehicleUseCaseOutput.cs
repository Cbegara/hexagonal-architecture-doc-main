namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase
{
    /// <summary>
    /// Output data for the AddVehicle use case.
    /// </summary>
    public sealed class AddVehicleUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the ID of the added vehicle.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the message indicating the result of the add operation.
        /// </summary>
        public string Message { get; set; }
    }
}
