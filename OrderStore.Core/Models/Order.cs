using System;
using System.Collections.Generic;
using System.Text;

namespace OrderStore.Core.Models
{
    public class Order
    {
        public Order(Guid id, string description, decimal price, string assignedTo, DateTime createdAt)
        {
            Id = id;
            Descriprion = description;
            TotalPrice = price;
            AssignedTo = assignedTo;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }
        public string Descriprion { get; }
        public decimal TotalPrice { get; }
        public string AssignedTo { get; }

        public  DateTime CreatedAt { get; }

        public List<OrderHistoryElement> History { get; set; }
            = new();

        public void ChangeStatus(string status, string author)
        {
            History.Add(new OrderHistoryElement(
                status,
                author,
                DateTime.UtcNow
            ));
        }

        public static (Order Order, string Error) Create(Guid id, string description, decimal price, string assignedTo, DateTime createdAt)
        {
            var error = string.Empty;
            var order = new Order(id, description, price, assignedTo, createdAt);
            return (order, error);
        }
    }
}