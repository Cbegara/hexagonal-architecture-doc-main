using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a rental entity with details about the rental period, customer, and vehicle.
    /// </summary>
    public sealed class Rental
    {
        /// <summary>
        /// Gets or sets the unique identifier for the rental.
        /// </summary>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string RentalId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        [BsonElement("customerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        [BsonElement("vehicleId")]
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rental.
        /// </summary>
        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental.
        /// </summary>
        [BsonElement("endDate")]
        public DateTime? EndDate { get; set; }

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
