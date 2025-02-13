using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public sealed class RentalRepository(IMongoDatabase database) : MongoRepository<Rental>(database, "Rentals"), IRentalRepository
    {
        public async Task<IEnumerable<Rental>> GetActiveRentalsAsync()
        {
            var filter = Builders<Rental>.Filter.Eq(v => v.EndDate, null);
            return await Collection.Find(filter).ToListAsync();
        }

        public async Task<bool> HasActiveRentalAsync(string customerName)
        {
            var count = await Collection.CountDocumentsAsync(
                Builders<Rental>.Filter.Where(r => r.CustomerName == customerName && r.EndDate == null));
            return count > 0;
        }

        public async Task CompleteRentalAsync(string rentalId, DateTime returnDate)
        {
            var update = Builders<Rental>.Update.Set(r => r.EndDate, returnDate);
            await Collection.UpdateOneAsync(r => r.RentalId == rentalId, update);
        }
    }
}
