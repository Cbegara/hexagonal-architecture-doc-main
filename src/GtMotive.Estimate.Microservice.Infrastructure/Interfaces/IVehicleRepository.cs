using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();

        Task AddAsync(Vehicle vehicle);

        Task<Vehicle> GetByIdAsync(string id);

        Task UpdateAsync(string id, Vehicle vehicle);
    }
}
