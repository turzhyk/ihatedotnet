using OrderStore.Core.Models;

namespace ProductStore.DataAccess.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public OrderItemType Type { get; set; }
    public IPricingStrategy PricingStrategy { get; set;}
    
}