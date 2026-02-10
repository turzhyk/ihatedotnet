using OrderStore.DataAccess.Entities;

namespace OrderStore.DataAccess.Entities;

public class OrderHistoryElementEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string Status { get; set; }
    public DateTime ChangedAt { get; set; }
    public string AuthorLogin { get; set; }
    public OrderEntity Order { get; set; }
}