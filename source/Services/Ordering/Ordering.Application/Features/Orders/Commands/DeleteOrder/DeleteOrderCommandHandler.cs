﻿using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.DeleteAsync(new Domain.EntityModels.Order() { Id = request.Id });
           
        }
    }
}
