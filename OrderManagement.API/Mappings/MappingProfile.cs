using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.UseCases.CreateOrder;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate));

            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
