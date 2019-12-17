using AutoMapper;
using Shopping.Core.BO;
using Shopping.Core.Domain.Order;
using Shopping.ViewModels;

namespace Shopping.MappingConfiguration
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Order, OrderBO>().ReverseMap();
            CreateMap<OrderItem, OrderItemBO>().ReverseMap();
            CreateMap<OrderBO, AddOrderItemsViewModel>().ReverseMap();
            CreateMap<OrderItemBO, UpdateOrderItemViewModel>().ReverseMap();

        }
    }
}
