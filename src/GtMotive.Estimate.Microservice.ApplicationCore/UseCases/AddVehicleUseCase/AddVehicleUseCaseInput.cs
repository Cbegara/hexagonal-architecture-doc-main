﻿using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase
{
    /// <summary>
    /// Represents the input data required to add a vehicle.
    /// </summary>
    public sealed class AddVehicleUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the make of the vehicle.
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing date of the vehicle.
        /// </summary>
        [Required]
        public int ManufacturingDate { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        [Required]
        public string LicensePlate { get; set; }
    }
}
