using IHateDotnet.Contracts;
using Microsoft.AspNetCore.Mvc;
using OrderStore.Application.Services;
using OrderStore.Core.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _service;
        public OrdersController(IOrdersService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrdersResponse>>> GetOrdersAsync()
        {
            var orders = await _service.GetAllOrders();
            var response = orders.Select(o => new OrdersResponse(o.Id, o.Descriprion, o.TotalPrice, o.AssignedTo));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] OrdersRequest request)
        {
            var (order, error) = Order.Create(Guid.NewGuid(), request.Desc, request.Price, "");
            await _service.CreateOrder(order);
            return Ok(order.Id);
        }
    }
}
