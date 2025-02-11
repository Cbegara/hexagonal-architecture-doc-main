using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase
{
    /// <summary>
    /// Output port for handling the response of the RentVehicle use case.
    /// </summary>
    public sealed class RentVehicleOutputPort : IOutputPortStandard<RentVehicleUseCaseOutput>
    {
        /// <summary>
        /// Handles the standard response for the RentVehicle use case.
        /// </summary>
        /// <param name="response">The response from the RentVehicle use case.</param>
        /// <exception cref="ArgumentNullException">Thrown when the response is null.</exception>
        public void StandardHandle(RentVehicleUseCaseOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            Console.WriteLine($"Vehicle Rented: Rental ID: {response.RentalId}, Message: {response.Message}");
        }
    }
}
