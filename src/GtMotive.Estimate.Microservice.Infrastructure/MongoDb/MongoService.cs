using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.MongoDbDatabaseName);
        }

        public IMongoCollection<Vehicle> VehiclesCollection => _database.GetCollection<Vehicle>("Vehicles");

        public IMongoCollection<Customer> CustomersCollection => _database.GetCollection<Customer>("Customers");

        public IMongoCollection<Rental> RentalsCollection => _database.GetCollection<Rental>("Rentals");
    }
}
