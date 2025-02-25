﻿using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase
{
    /// <summary>
    /// Output port for handling the return vehicle use case response.
    /// </summary>
    public sealed class ReturnVehicleOutputPort : IOutputPortStandard<ReturnVehicleUseCaseOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the standard response for the return vehicle use case.
        /// </summary>
        /// <param name="response">The response from the return vehicle use case.</param>
        /// <exception cref="ArgumentNullException">Thrown when the response is null.</exception>
        public void StandardHandle(ReturnVehicleUseCaseOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            Console.WriteLine($"Vehicle Returned: Rental ID: {response.RentalId}, Message: {response.Message}");
        }

        /// <summary>
        /// Handles the not found response for the return vehicle use case.
        /// </summary>
        /// <param name="message">The error message indicating the vehicle was not found.</param>
        public void NotFoundHandle(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
