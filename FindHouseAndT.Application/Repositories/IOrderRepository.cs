﻿using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IOrderRepository
    {
        public Task CreateOrderAsync(Order order);
        public Task UpdateOrderAsync(Order order);
        public Task<IEnumerable<Order>> GetAllOrderAsync();
        public Task<Order?> GetOrderByIdAsync(Guid id);
    }
}
