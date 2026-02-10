using Microsoft.EntityFrameworkCore;
using OrderStore.Core.Models;
using OrderStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderStore.DataAccess.Repos
{
    public class OrdersRepository : IOrdersRepository

    {
        private readonly OrderStoreDbContext _context;

        public OrdersRepository(OrderStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetWithId(Guid id)
        {
            var order = await _context.Orders.Where(o => o.Id == id)
                .Select(o => Order.Create(
                    o.Id,
                    o.Descriprion,
                    o.TotalPrice,
                    null,
                    o.AssignedTo,
                    o.CreatedAt,
                    o.Status,
                    o.PaymentStatus,
                    null
                ).Order)
                .FirstOrDefaultAsync();
            if (order != null)
                return order;
            else
            {
                throw new Exception($"Order with id {id} not found");
                return null;
            }
        }

        public async Task<List<Order>> GetAll()
        {
            var orderEntities =
                await _context.Orders
                    .AsNoTracking()
                    .Include(o => o.Items)
                    .Include(o => o.History)
                    .ToListAsync();

            var orders = orderEntities.Select(o =>
                {
                    var items = o.Items.Select(i => new OrderItem
                    {
                        Id = i.Id,
                        Quantity = i.Quantity,
                        Type = i.Type,
                        PricePerUnit = i.PricePerUnit,
                        Options = i.Options
                    }).ToList();
                    var history = o.History.Select(h => new OrderHistoryElement
                    {
                        Id = h.Id,
                        Status = h.Status,
                        ChangedAt = h.ChangedAt,
                        AuthorLogin = h.AuthorLogin,
                        OrderId = o.Id
                    }).ToList();
                    return Order.Create(
                        o.Id,
                        o.Descriprion,
                        o.TotalPrice,
                        items,
                        o.AssignedTo,
                        o.CreatedAt,
                        o.Status,
                        o.PaymentStatus,
                        history
                    ).Order;
                })
                .ToList();
            return orders;
        }

        public async Task<Guid> Create(Order order)
        {
            var initHistoryElement = new OrderHistoryElementEntity
            {
                OrderId = order.Id,
                Status = "New",
                ChangedAt = DateTime.UtcNow,
                AuthorLogin = "-",
                Id = Guid.NewGuid()
            };
            List<OrderHistoryElementEntity> history = new List<OrderHistoryElementEntity>();
            history.Add(initHistoryElement);
            var items = order.Items.Select(i => new OrderItemEntity
            {
                Id = i.Id,
                Quantity = i.Quantity,
                Type = i.Type,
                PricePerUnit = i.PricePerUnit,
                Options = i.Options,
            }).ToList();
            var orderEntity = new OrderEntity
            {
                Id = order.Id,
                Descriprion = order.Descriprion,
                TotalPrice = order.TotalPrice,
                AssignedTo = order.AssignedTo,
                Items = items,
                History = history,
                CreatedAt = order.CreatedAt,
                PaymentStatus = order.PaymentStatus,
                Status = order.Status
            };
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task AssignOrderWithStatus(
            Guid orderId,
            string author,
            OrderHistoryElement historyElement)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new Exception($"No order found with id {orderId}");

            order.AssignedTo = author;

            _context.OrderStatusHistories.Add(new OrderHistoryElementEntity
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                Status = historyElement.Status,
                AuthorLogin = historyElement.AuthorLogin,
                ChangedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }


        public async Task Update(Order order)
        {
            var orderEntity =
                await _context.Orders.Include(o => o.History).FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderEntity == null)
                throw new Exception("Order not found");
            orderEntity.History.Add(new OrderHistoryElementEntity
            {
                Order = orderEntity,
                Status = order.History.Last().Status,
                AuthorLogin = order.History.Last().AuthorLogin,
                ChangedAt = order.History.Last().ChangedAt,
                
            });
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> Update(Guid id, string description, decimal price, string assignedTo)
        {
            await _context.Orders.Where(o => o.Id == id).ExecuteUpdateAsync(i => i
                .SetProperty(o => o.Descriprion, o => description)
                .SetProperty(o => o.TotalPrice, o => price)
                .SetProperty(o => o.AssignedTo, o => assignedTo));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Orders.Where(o => o.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}