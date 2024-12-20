using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            //Business Rules/Logic

            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .NotNull().WithMessage("Username cannot be null.")
                .EmailAddress().WithMessage("Username must be a valid email address.");

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            RuleFor(c => c.TotalPrice)
                .GreaterThan(0).WithMessage("Total price must be greater than zero.");

            RuleFor(c => c.EmailAddress)
                .EmailAddress().WithMessage("Email address must be valid.");
        }

    }
}
