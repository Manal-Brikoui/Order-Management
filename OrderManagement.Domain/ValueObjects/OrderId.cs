using System;

namespace OrderManagement.Domain.ValueObjects
{
    public class OrderId
    {
     
        public Guid Id { get; }

        public OrderId(Guid id)
        {
          
            if (id == Guid.Empty)
                throw new ArgumentException("OrderId cannot be empty", nameof(id));

            Id = id;
        }

        // Méthode statique pour créer un nouvel ID unique
        public static OrderId New()
        {
            return new OrderId(Guid.NewGuid());
        }

       
        public override bool Equals(object? obj)
        {
            if (obj is OrderId other)
            {
                return Id.Equals(other.Id);
            }
            return false;
        }

       
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public static implicit operator OrderId(Guid id) => new OrderId(id);
        public static implicit operator Guid(OrderId orderId) => orderId.Id;
    }
}
