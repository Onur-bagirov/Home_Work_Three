using EShopp.Domain.Entities;
namespace EShopp.Aplication.Abstracts
{
    public interface IOrderService
    {
        Task AddOrderAsync(Order order);
        Task RemoveOrderAsync(int orderId);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);
    }
}