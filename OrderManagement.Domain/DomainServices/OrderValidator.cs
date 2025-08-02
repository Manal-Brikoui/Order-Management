using System;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.DomainServices
{
    public class OrderValidator
    {
        // Valide une commande en s'assurant que tous les champs nécessaires sont valides
        public static bool IsValidOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "La commande ne peut pas être nulle.");
            }

            // Vérifie que le nom du client est fourni et n'est pas vide
            if (string.IsNullOrEmpty(order.CustomerName))
            {
                return false; // Le nom du client ne doit pas être vide ou null
            }

            // Vérifie que l'adresse est fournie et n'est pas vide
            if (string.IsNullOrEmpty(order.Address))
            {
                return false; // L'adresse ne doit pas être vide ou null
            }

            // Vérifie que la date de la commande n'est pas dans le futur
            if (order.OrderDate > DateTime.Now)
            {
                return false; // La date de la commande ne peut pas être dans le futur
            }

            return true;
        }
    }
}
