using OrderStore.Core.Models;

namespace OrderStore.DataAccess.Repos
{
    public interface IOrdersRepository
    {
        Task<Guid> Create(Order order);
        Task<Guid> Delete(Guid id);
        Task<List<Order>> GetAll();
        Task<Order> GetWithId(Guid id);
        Task Update(Order order);
        Task<Guid> Update(Guid id, string description, decimal price, string assignedTo);

        Task AssignOrderWithStatus(
            Guid orderId,
            string author,
            OrderHistoryElement historyElement);
    }
}