using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a customer entity with an ID, name, surname, and email.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// </remarks>
    /// <param name="id">The unique identifier for the customer.</param>
    /// <param name="fullName">The full name of the customer.</param>
    /// <param name="email">The email address of the customer.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public sealed class Customer(Guid? id, string fullName, string email)
    {
        /// <summary>
        /// Gets the unique identifier for the customer.
        /// </summary>
        public Guid Id { get; private set; } = id ?? throw new ArgumentNullException(nameof(id));

        /// <summary>
        /// Gets the full name of the customer.
        /// </summary>
        public string FullName { get; private set; } = fullName ?? throw new ArgumentNullException(nameof(fullName));

        /// <summary>
        /// Gets the email address of the customer.
        /// </summary>
        public string Email { get; private set; } = email ?? throw new ArgumentNullException(nameof(email));

        /// <summary>
        /// Gets a value indicating whether the customer has an active rental.
        /// </summary>
        public bool HasActiveRental { get; private set; }

        /// <summary>
        /// Marks the customer as having rented a vehicle.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the customer already has an active rental.</exception>
        public void RentVehicle()
        {
            if (HasActiveRental)
            {
                throw new InvalidOperationException("Customer already has an active rental.");
            }

            HasActiveRental = true;
        }

        /// <summary>
        /// Marks the customer as having returned a vehicle.
        /// </summary>
        public void ReturnVehicle()
        {
            HasActiveRental = false;
        }
    }
}
