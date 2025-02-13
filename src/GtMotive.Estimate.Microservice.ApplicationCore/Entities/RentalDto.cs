using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Entities
{
    /// <summary>
    /// Represents a rental data transfer object.
    /// </summary>
    public class RentalDto
    {
        /// <summary>
        /// Gets or sets the rental identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the rental date.
        /// </summary>
        public DateTime RentalDate { get; set; }
    }
}
