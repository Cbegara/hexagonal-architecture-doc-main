using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase
{
    /// <summary>
    /// Output class for the ListActiveRentals use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListActiveRentalsUseCaseOutput"/> class.
    /// </remarks>
    /// <param name="activeRentals">The list of active rentals.</param>
    public sealed class ListActiveRentalsUseCaseOutput(IEnumerable<RentalDto> activeRentals) : IUseCaseOutput
    {
        private readonly List<RentalDto> _activeRentals = activeRentals.ToList();

        /// <summary>
        /// Gets the collection of active rentals.
        /// </summary>
        public IReadOnlyCollection<RentalDto> ActiveRentals => _activeRentals.AsReadOnly();
    }
}
