namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }

        public Order(Guid orderId, string customerName, string address, DateTime orderDate)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Address = address;
            OrderDate = orderDate;
        }
    }
}
