using EShopp.Aplication.Abstracts;
using EShopp.DAL.Context;
using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace EShopp.Aplication.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly EShoppDbContext _context;
        public OrderService(EShoppDbContext context)
        {
            _context = context;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task RemoveOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
