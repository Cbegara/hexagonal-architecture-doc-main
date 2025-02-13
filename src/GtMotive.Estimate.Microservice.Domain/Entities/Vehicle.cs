using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle entity with properties such as Id, Brand, Model, LicensePlate, YearOfManufacture, and IsAvailable.
    /// </summary>
    public sealed class Vehicle
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the brand of the vehicle.
        /// </summary>
        [BsonElement("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        [BsonElement("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        [BsonElement("licensePlate")]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the year the vehicle was manufactured.
        /// </summary>
        [BsonElement("yearOfManufacture")]
        public int YearOfManufacture { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is available for rent.
        /// </summary>
        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
