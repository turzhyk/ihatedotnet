using System.Text.Json.Nodes;

namespace OrderStore.Core.Models;

public enum OrderItemType
{
    Businesscard,
    Banner,
    ReadyMade
}
public class OrderItem
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public OrderItemType Type { get; set; }
    public string Options { get; set; }
}