using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task<List<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(Guid id);
    }
}
