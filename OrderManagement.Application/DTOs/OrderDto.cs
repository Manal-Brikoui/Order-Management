namespace OrderManagement.Application.DTOs
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public class UpdateOrderDto
        {
            public Guid OrderId { get; set; }
            public string CustomerName { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public DateTime OrderDate { get; set; }
        }
    }
}
