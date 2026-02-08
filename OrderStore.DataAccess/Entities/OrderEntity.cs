using OrderStore.Core.Models;

namespace OrderStore.DataAccess.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public string Descriprion { get; set; }
        public decimal TotalPrice { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<OrderHistoryElementEntity> History { get; set; }
    }
}
