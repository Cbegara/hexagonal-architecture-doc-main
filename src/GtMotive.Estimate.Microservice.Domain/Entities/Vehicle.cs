using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle entity with properties such as Id, Brand, Model, LicensePlate, YearOfManufacture, and IsAvailable.
    /// </summary>
    public sealed class Vehicle
    {
        /// <summary>
        /// The maximum age of the vehicle in years.
        /// </summary>
        private const int MaxVehicleAge = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="yearOfManufacture">The year the vehicle was manufactured.</param>
        /// <exception cref="ArgumentException">Thrown when the vehicle is older than 5 years.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the required parameters are null.</exception>
        public Vehicle(Guid? id, string brand, string model, string licensePlate, int yearOfManufacture)
        {
            if (yearOfManufacture < DateTime.UtcNow.Year - MaxVehicleAge)
            {
                throw new ArgumentException("Vehicle cannot be older than 5 years.");
            }

            Id = id ?? throw new ArgumentNullException(nameof(id));
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            LicensePlate = licensePlate ?? throw new ArgumentNullException(nameof(licensePlate));
            YearOfManufacture = yearOfManufacture;
            IsAvailable = true;
        }

        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; private set; }

        /// <summary>
        /// Gets the year the vehicle was manufactured.
        /// </summary>
        public int YearOfManufacture { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available for rent.
        /// </summary>
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Marks the vehicle as rented.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the vehicle is already rented.</exception>
        public void MarkAsRented()
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("Vehicle is already rented.");
            }

            IsAvailable = false;
        }

        /// <summary>
        /// Marks the vehicle as returned and available for rent.
        /// </summary>
        public void MarkAsReturned()
        {
            IsAvailable = true;
        }
    }
}
