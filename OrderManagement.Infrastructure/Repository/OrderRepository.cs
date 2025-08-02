using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid orderId)
        {
            return await _context.orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.orders.ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid orderId)
        {
            var order = await _context.orders.FindAsync(orderId);
            if (order != null)
            {
                _context.orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
