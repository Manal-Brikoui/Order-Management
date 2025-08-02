namespace OrderManagement.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Customer(Guid customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
        }
    }
}
