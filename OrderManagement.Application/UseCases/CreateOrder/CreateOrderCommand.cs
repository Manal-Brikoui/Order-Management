namespace OrderManagement.Application.UseCases.CreateOrder
{
    public class CreateOrderCommand
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
