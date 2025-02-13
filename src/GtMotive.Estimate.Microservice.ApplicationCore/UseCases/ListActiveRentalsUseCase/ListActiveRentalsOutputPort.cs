using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase
{
    /// <summary>
    /// Output port for handling the response of the ListActiveRentals use case.
    /// </summary>
    public sealed class ListActiveRentalsOutputPort : IOutputPortStandard<ListActiveRentalsUseCaseOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the standard response for the ListActiveRentals use case.
        /// </summary>
        /// <param name="response">The response containing the active rentals.</param>
        public void StandardHandle(ListActiveRentalsUseCaseOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            foreach (var rental in response.ActiveRentals)
            {
                Console.WriteLine($"RentalId: {rental.Id}, CustomerName: {rental.CustomerName}");
            }
        }

        /// <summary>
        /// Handles the case when no active rentals are found.
        /// </summary>
        /// <param name="message">The error message indicating no active rentals were found.</param>
        public void NotFoundHandle(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
