using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.UseCases.CreateOrder
{
    public class CreateOrderHandler
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> HandleAsync(CreateOrderCommand command)
        {
            // Création de l'objet Order avec les données du command
            var order = new Order(
                command.OrderId,
                command.CustomerName,
                command.Address,
                command.OrderDate);

            // Appel du repository pour ajouter la commande
            await _orderRepository.AddAsync(order);

            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                Address = order.Address,
                OrderDate = order.OrderDate
            };
        }
    }
}
