using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase
{
    /// <summary>
    /// Output port for handling the response of adding a vehicle.
    /// </summary>
    public sealed class AddVehicleOutputPort : IOutputPortStandard<AddVehicleUseCaseOutput>
    {
        /// <summary>
        /// Handles the standard response for adding a vehicle.
        /// </summary>
        /// <param name="response">The response containing the vehicle ID and message.</param>
        public void StandardHandle(AddVehicleUseCaseOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            Console.WriteLine($"Vehicle Created: {response.VehicleId}, Message: {response.Message}");
        }
    }
}
