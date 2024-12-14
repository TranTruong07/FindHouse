using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FindHouseDbContext _houseDbContext;
        public CustomerRepository(FindHouseDbContext context) 
        {
            _houseDbContext = context;
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
            await _houseDbContext.AddAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            List<Customer> customers = await _houseDbContext.Customers.Include(x => x.UserApp).ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            Customer? customer = await _houseDbContext.Customers.Include(x => x.UserApp).Where(x => x.IdUser.Equals(id)).SingleOrDefaultAsync();
            return customer;
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            _houseDbContext.Customers.Update(customer);
            return Task.CompletedTask;
        }
    }
}
