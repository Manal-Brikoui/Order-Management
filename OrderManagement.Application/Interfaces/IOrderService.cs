using OrderManagement.Application.DTOs;
using OrderManagement.Application.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static OrderManagement.Application.DTOs.OrderDto;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        // Créer une nouvelle commande
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);

        // Récupérer une commande par son identifiant
        Task<OrderDto?> GetOrderByIdAsync(Guid orderId);

        // Récupérer toutes les commandes
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

        // Mettre à jour une commande existante
        Task<OrderDto> UpdateOrderAsync(UpdateOrderDto updateOrderDto);

        // Supprimer une commande
        Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
