using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase
{
    /// <summary>
    /// Input data for the ReturnVehicle use case.
    /// </summary>
    public sealed class ReturnVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the rental identifier.
        /// </summary>
        [Required]
        public string RentalId { get; set; }
    }
}
