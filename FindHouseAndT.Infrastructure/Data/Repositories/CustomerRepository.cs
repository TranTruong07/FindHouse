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
        public Task CreateCustomerAsync(Customer customer)
        {
            _houseDbContext.AddAsync(customer);
            return Task.CompletedTask;
        }

        public Task<List<Customer>> GetAllCustomerAsync()
        {
            return _houseDbContext.Customers.ToListAsync();
        }

        public Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return _houseDbContext.Customers.Include(x => x.UserApp).Where(x => x.IdUser.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            _houseDbContext.Customers.Update(customer);
            return Task.CompletedTask;
        }
    }
}
