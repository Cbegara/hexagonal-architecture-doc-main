using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    public class MongoDbFixture : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;
        private bool _disposed;

        public MongoDbFixture()
        {
            var services = new ServiceCollection();

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("IntegrationTestDb");

            services.AddSingleton<IRentalRepository>(new RentalRepository(database));

            _serviceProvider = services.BuildServiceProvider();

            // Insertar datos iniciales en la base de datos
            InsertInitialData(database);
        }

        public IServiceProvider ServiceProvider => _serviceProvider;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _serviceProvider?.Dispose();

                    var client = new MongoClient("mongodb://localhost:27017");
                    client.DropDatabase("IntegrationTestDb");
                }

                _disposed = true;
            }
        }

        private static void InsertInitialData(IMongoDatabase database)
        {
            // Datos de ejemplo para insertar
            var rentalCollection = database.GetCollection<Rental>("Rentals");
            var initialRentals = new List<Rental>
        {
            new Rental
            {
                CustomerName = "customer1",
                StartDate = DateTime.Now,
                EndDate = null
            },
            new Rental
            {
                CustomerName = "customer2",
                StartDate = DateTime.Now,
                EndDate = null
            }
        };

            rentalCollection.InsertMany(initialRentals);
        }
    }
}
