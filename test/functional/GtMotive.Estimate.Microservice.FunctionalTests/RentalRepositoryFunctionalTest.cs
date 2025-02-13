using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests
{
    [Collection(TestCollections.Functional)]
    public sealed class RentalRepositoryFunctionalTest(MongoDbFixture fixture) : IClassFixture<MongoDbFixture>
    {
        private readonly IRentalRepository _rentalRepository = fixture.ServiceProvider.GetRequiredService<IRentalRepository>();

        [Fact]
        public async Task HasActiveRentalAsyncShouldReturnFalseIfCustomerHasNotActiveRentalAfterComplete()
        {
            var activeRentals = await _rentalRepository.GetActiveRentalsAsync();
            var hasActiveRental = await _rentalRepository.HasActiveRentalAsync("customer1");
            Assert.True(hasActiveRental);

            await _rentalRepository.CompleteRentalAsync(activeRentals.FirstOrDefault().RentalId, DateTime.Now);
            hasActiveRental = await _rentalRepository.HasActiveRentalAsync("customer1");
            Assert.False(hasActiveRental);
        }

        [Fact]
        public async Task GetActiveRentalsAsyncShouldReturnActiveRentals()
        {
            var activeRentals = await _rentalRepository.GetActiveRentalsAsync();

            Assert.NotEmpty(activeRentals);
            Assert.Contains(activeRentals, r => r.CustomerName == "customer2");
        }
    }
}
