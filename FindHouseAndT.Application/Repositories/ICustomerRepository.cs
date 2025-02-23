using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(Guid id);
    }
}
