using OrderStore.Core.Models;
using OrderStore.DataAccess.Repos;


namespace OrderStore.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _repo;
        public OrdersService(IOrdersRepository ordersRepo)
        {
            _repo = ordersRepo;
        }
        public async Task<List<Order>> GetAllOrders() => await _repo.GetAll();
        public async Task<Guid> CreateOrder(Order order) => await _repo.Create(order);

        public async Task ChangeStatusAsync(Guid orderId, string status, string author)
        {
            var order = await _repo.GetWithId(orderId);
            if (order == null)
                throw new Exception($"Order {orderId} not found");
            order.ChangeStatus(status, author);
            await _repo.Update(order);
        }
    }
}
