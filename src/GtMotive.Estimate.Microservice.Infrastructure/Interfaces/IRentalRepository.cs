using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetActiveRentalsAsync();

        Task<bool> HasActiveRentalAsync(string customerName);

        Task AddAsync(Rental rental);

        Task<Rental> GetByIdAsync(string id);

        Task CompleteRentalAsync(string rentalId, DateTime returnDate);
    }
}
