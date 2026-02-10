using OrderStore.Core.Models;

namespace OrderStore.Application.Services
{
    public interface IOrdersService
    {
        Task<Guid> CreateOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task AssignToAsync(Guid orderId, string author);
    }
}