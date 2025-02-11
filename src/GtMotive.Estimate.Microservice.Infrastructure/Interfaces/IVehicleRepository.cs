using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();

        Task AddAsync(Vehicle vehicle);

        Task<Vehicle> GetByIdAsync(Guid id);

        Task<bool> ExistsAsync(Guid vehicleId);

        Task<bool> IsAvailableAsync(Guid vehicleId);

        Task UpdateAvailabilityAsync(Guid vehicleId, bool isAvailable);

        Task UpdateAsync(Guid id, Vehicle vehicle);
    }
}
