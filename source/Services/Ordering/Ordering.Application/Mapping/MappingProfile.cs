﻿using AutoMapper;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.UpdateFolder;
using Ordering.Application.Features.Orders.Queries.GetOrdersByUserName;
using Ordering.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order,OrderVm>().ReverseMap();
            CreateMap<Order,CreateOrderCommand>().ReverseMap();
            CreateMap<Order,UpdateOrderCommand>().ReverseMap();
        }
    }
}
