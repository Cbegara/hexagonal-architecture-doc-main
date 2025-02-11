using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IRentalRepository
    {
        Task<Rental> GetActiveRentalByCustomerAsync(Guid customerId);

        Task<bool> HasActiveRentalAsync(Guid customerId);

        Task AddAsync(Rental rental);

        Task<Rental> GetByIdAsync(Guid id);

        Task CompleteRentalAsync(Guid rentalId, DateTime returnDate);
    }
}
