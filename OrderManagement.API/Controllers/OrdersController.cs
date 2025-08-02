using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.CreateOrder;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Application.DTOs;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CreateOrderHandler _createOrderHandler;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(CreateOrderHandler createOrderHandler, IOrderRepository orderRepository)
        {
            _createOrderHandler = createOrderHandler;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null)
            {
                return BadRequest();
            }

            var command = new CreateOrderCommand
            {
                CustomerName = createOrderDto.CustomerName,
                Address = createOrderDto.Address
            };

            var result = await _createOrderHandler.HandleAsync(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = result.OrderId }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
