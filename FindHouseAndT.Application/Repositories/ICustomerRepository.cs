using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface ICustomerRepository
    {
        public Task CreateCustomerAsync(Customer customer);
        public Task UpdateCustomerAsync(Customer customer);
        public Task<IEnumerable<Customer>> GetAllCustomerAsync();
        public Task<Customer?> GetCustomerByIdAsync(Guid id);
    }
}
