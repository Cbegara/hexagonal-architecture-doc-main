using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a rental entity with details about the rental period and associated customer and vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// </remarks>
    /// <param name="id">The unique identifier for the rental.</param>
    /// <param name="customerId">The unique identifier for the customer.</param>
    /// <param name="vehicleId">The unique identifier for the vehicle.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public sealed class Rental(Guid? id, Guid? customerId, Guid? vehicleId)
    {
        /// <summary>
        /// Gets the unique identifier for the rental.
        /// </summary>
        public Guid Id { get; private set; } = id ?? throw new ArgumentNullException(nameof(id));

        /// <summary>
        /// Gets the unique identifier for the customer.
        /// </summary>
        public Guid CustomerId { get; private set; } = customerId ?? throw new ArgumentNullException(nameof(customerId));

        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public Guid VehicleId { get; private set; } = vehicleId ?? throw new ArgumentNullException(nameof(vehicleId));

        /// <summary>
        /// Gets the start date of the rental.
        /// </summary>
        public DateTime StartDate { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets the end date of the rental.
        /// </summary>
        public DateTime? EndDate { get; private set; }

        /// <summary>
        /// Marks the vehicle as returned by setting the end date to the current date and time.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the vehicle has already been returned.</exception>
        public void ReturnVehicle()
        {
            if (EndDate.HasValue)
            {
                throw new InvalidOperationException("Vehicle has already been returned.");
            }

            EndDate = DateTime.UtcNow;
        }
    }
}
