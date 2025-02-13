using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public sealed class VehicleRepository(IMongoDatabase database) :
        MongoRepository<Vehicle>(database, "Vehicles"), IVehicleRepository
    {
        public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.IsAvailable, true);
            return await Collection.Find(filter).ToListAsync();
        }
    }
}
