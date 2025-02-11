using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public sealed class RentalRepository(IMongoDatabase database) : MongoRepository<Rental>(database, "Rentals"), IRentalRepository
    {
        public async Task<Rental> GetActiveRentalByCustomerAsync(Guid customerId)
        {
            var filter = Builders<Rental>.Filter.Where(r => r.CustomerId == customerId &&
                                                                        r.EndDate == null);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> HasActiveRentalAsync(Guid customerId)
        {
            var count = await Collection.CountDocumentsAsync(
                Builders<Rental>.Filter.Where(r => r.CustomerId == customerId && r.EndDate == null));
            return count > 0;
        }

        public async Task CompleteRentalAsync(Guid rentalId, DateTime returnDate)
        {
            var update = Builders<Rental>.Update.Set(r => r.EndDate, returnDate);
            await Collection.UpdateOneAsync(r => r.Id == rentalId, update);
        }
    }
}
