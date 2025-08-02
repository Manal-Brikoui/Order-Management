using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid orderId);
        Task<IEnumerable<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid orderId);
    }
}
