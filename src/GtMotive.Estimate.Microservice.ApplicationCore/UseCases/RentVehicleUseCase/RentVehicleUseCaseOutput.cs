using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase
{
    /// <summary>
    /// Output data for the RentVehicle use case.
    /// </summary>
    public sealed class RentVehicleUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the unique identifier for the rental.
        /// </summary>
        [Required]
        public string RentalId { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the rental operation.
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}
