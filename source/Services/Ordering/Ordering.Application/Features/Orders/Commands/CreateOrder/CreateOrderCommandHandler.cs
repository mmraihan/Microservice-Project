using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        IEmailService _emailService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order.CreatedBy = "1";
            order.CreatedDate = DateTime.Now;
            bool isOrderPlaced = await _orderRepository.AddAsync(order);
            if (isOrderPlaced)
            {
                EmailMessage email = new EmailMessage();
                email.Subject = "Your Order Has Been Successfully Placed";
                email.To = order.UserName;
                email.Body = $"Dear {order.FirstName} {order.LastName},<br/><br/>" +
                             $"We are thrilled to inform you that your order (Order ID: #{order.Id}) has been successfully placed. " +
                             $"We will notify you as soon as it is on its way.<br/><br/>" +
                             "Thank you for shopping with Mubasshir Raihan Team.<br/><br/>" +
                             "Best regards,<br/>" +
                             "The Mubasshir Raihan Team";
                await _emailService.SendEmailAsync(email);
            }

            return isOrderPlaced;
        }
    }
}
