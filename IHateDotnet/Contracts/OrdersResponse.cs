namespace IHateDotnet.Contracts
{
    public class OrdersResponse{
        public Guid id { get; set; }
        public string Desc{ get; set; }
        public decimal Price{ get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public string AssignedTo{ get; set; }
        public DateTime CreatedAt{ get; set; }
        public List<OrderHistoryElementResponse> History { get; set; }

    };
    
}