using System;
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

        public async Task<bool> ExistsAsync(Guid vehicleId)
        {
            var count = await Collection.CountDocumentsAsync(Builders<Vehicle>.Filter.Eq(v => v.Id, vehicleId));
            return count > 0;
        }

        public async Task<bool> IsAvailableAsync(Guid vehicleId)
        {
            var vehicle = await Collection.Find(v => v.Id == vehicleId).FirstOrDefaultAsync();
            return vehicle?.IsAvailable ?? false;
        }

        public async Task UpdateAvailabilityAsync(Guid vehicleId, bool isAvailable)
        {
            var update = Builders<Vehicle>.Update.Set(v => v.IsAvailable, isAvailable);
            await Collection.UpdateOneAsync(v => v.Id == vehicleId, update);
        }
    }
}
