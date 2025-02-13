using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase
{
    /// <summary>
    /// Represents the input data required to rent a vehicle.
    /// </summary>
    public sealed class RentVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        [Required]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the vehicle.
        /// </summary>
        [Required]
        public string VehicleId { get; set; }
    }
}
