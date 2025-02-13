using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase
{
    /// <summary>
    /// Output port for handling the response of adding a vehicle.
    /// </summary>
    public sealed class AddVehicleOutputPort : IOutputPortStandard<AddVehicleUseCaseOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the standard response when a vehicle is successfully added.
        /// </summary>
        /// <param name="response">The response containing the details of the added vehicle.</param>
        public void StandardHandle(AddVehicleUseCaseOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            Console.WriteLine($"Vehicle Created: {response.VehicleId}, Message: {response.Message}");
        }

        /// <summary>
        /// Handles the response when the vehicle to be added is not found.
        /// </summary>
        /// <param name="message">The error message indicating the vehicle was not found.</param>
        public void NotFoundHandle(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
