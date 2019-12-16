using AutoMapper;
using Shopping.Core.BO;
using Shopping.Data.Models;
using Shopping.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
