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
        public async Task CreateOrderAsync(Order order)
        {
            await _houseDbContext.Orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _houseDbContext.Orders.Include(x => x.Customer).Include(x => x.Room).Include(x => x.HouseOwner).Include(x => x.Motel).ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _houseDbContext.Orders.Include(x => x.Customer).Include(x => x.Room).Include(x => x.HouseOwner).Include(x => x.Motel).FirstOrDefaultAsync(x => x.IdOrder.Equals(id));
        }

        public Task UpdateOrderAsync(Order order)
        {
            _houseDbContext.Orders.Update(order);
            return Task.CompletedTask;
        }
    }
}
