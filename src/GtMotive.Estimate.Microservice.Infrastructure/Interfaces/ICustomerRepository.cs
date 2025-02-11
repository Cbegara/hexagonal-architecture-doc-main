using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> ExistsAsync(Guid customerId);

        Task AddAsync(Customer customer);

        Task<Customer> GetByIdAsync(Guid id);
    }
}
