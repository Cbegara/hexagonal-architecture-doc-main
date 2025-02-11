using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public sealed class CustomerRepository(IMongoDatabase database) : MongoRepository<Customer>(database, "Customers"), ICustomerRepository
    {
        public async Task<bool> ExistsAsync(Guid customerId)
        {
            var count = await Collection.CountDocumentsAsync(Builders<Customer>.Filter.Eq(c => c.Id, customerId));
            return count > 0;
        }
    }
}
