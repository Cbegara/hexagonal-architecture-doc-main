using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase
{
    /// <summary>
    /// Output port for handling the response of the ListAvailableVehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesOutputPort : IOutputPortStandard<ListAvailableVehiclesUseCaseOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the standard response for the ListAvailableVehicles use case.
        /// </summary>
        /// <param name="response">The response containing the list of available vehicles.</param>
        /// <exception cref="ArgumentNullException">Thrown when the response is null.</exception>
        public void StandardHandle(ListAvailableVehiclesUseCaseOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            foreach (var vehicle in response.AvailableVehicles)
            {
                Console.WriteLine($"Vehicle: {vehicle.Brand} {vehicle.Model}, License Plate: {vehicle.LicensePlate}");
            }
        }

        /// <summary>
        /// Handles the case when no vehicles are found.
        /// </summary>
        /// <param name="message">The error message indicating no vehicles were found.</param>
        public void NotFoundHandle(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
