using OrderStore.Core.Models;

namespace IHateDotnet.Contracts;

public class OrderItemResponse
{
    public int Quantity { get; set; }
    public OrderItemType Type { get; set; }
    public decimal PricePerUnit { get; set; }
    public string Options { get; set; }
}