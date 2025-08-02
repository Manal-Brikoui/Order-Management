using System;

namespace OrderManagement.Domain.ValueObjects
{
    public class OrderId
    {
        // Propriété en lecture seule pour garantir l'immuabilité
        public Guid Id { get; }

        // Constructeur qui vérifie que l'ID n'est pas vide
        public OrderId(Guid id)
        {
            // Si l'ID est vide, on lance une exception
            if (id == Guid.Empty)
                throw new ArgumentException("OrderId cannot be empty", nameof(id));

            Id = id;
        }

        // Méthode statique pour créer un nouvel ID unique
        public static OrderId New()
        {
            return new OrderId(Guid.NewGuid());
        }

        // Surcharge de Equals pour comparer deux objets OrderId
        public override bool Equals(object? obj)
        {
            if (obj is OrderId other)
            {
                return Id.Equals(other.Id);
            }
            return false;
        }

        // Surcharge de GetHashCode pour générer un code de hachage basé sur l'ID
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        // Représentation sous forme de chaîne de l'OrderId
        public override string ToString()
        {
            return Id.ToString();
        }

        // Optionnel : Méthode d'extension pour faciliter la conversion d'un Guid en OrderId
        public static implicit operator OrderId(Guid id) => new OrderId(id);
        public static implicit operator Guid(OrderId orderId) => orderId.Id;
    }
}
