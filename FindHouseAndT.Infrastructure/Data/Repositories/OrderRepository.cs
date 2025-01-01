using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FindHouseDbContext _houseDbContext;
        public OrderRepository(FindHouseDbContext context)
        {
            _houseDbContext = context;
        }
        public Task CreateOrderAsync(Order order)
        {
            _houseDbContext.Orders.AddAsync(order);
            return Task.CompletedTask;
        }

        public Task<List<Order>> GetAllOrderAsync()
        {
            return _houseDbContext.Orders.Include(x => x.Customer).Include(x => x.Room).ToListAsync();
        }

        public Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return _houseDbContext.Orders.Include(x => x.Customer).Include(x => x.Room).FirstOrDefaultAsync(x => x.IdOrder.Equals(id));
        }

        public Task UpdateOrderAsync(Order order)
        {
            _houseDbContext.Orders.Update(order);
            return Task.CompletedTask;
        }
    }
}
