using OrderStore.Core.Models;

namespace IHateDotnet.Contracts;

public class OrderItemRequest
{
    public int Quantity { get; set; }
    public OrderItemType Type { get; set; }
    public decimal PricePerUnit { get; set; }
    public string Options { get; set; }
}
