namespace OrderManagement.Application.UseCases.CreateOrder
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
