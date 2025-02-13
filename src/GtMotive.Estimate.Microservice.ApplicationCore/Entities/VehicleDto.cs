namespace GtMotive.Estimate.Microservice.ApplicationCore.Entities
{
    /// <summary>
    /// Data transfer object representing a vehicle.
    /// </summary>
    public class VehicleDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the make of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the year the vehicle was manufactured.
        /// </summary>
        public int YearOfManufacture { get; set; }
    }
}
