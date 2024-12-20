using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateFolder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("The order ID must be greater than zero.");

            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("The username is required.")
                .NotNull().WithMessage("The username cannot be null.")
                .EmailAddress().WithMessage("The username must be a valid email address.");

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("The first name is required.")
                .MaximumLength(100).WithMessage("The first name cannot exceed 100 characters.");

            RuleFor(c => c.TotalPrice)
                .GreaterThan(0).WithMessage("The total price must be greater than zero.");

            RuleFor(c => c.EmailAddress)
                .EmailAddress().WithMessage("The email address must be valid.");
        }

    }
}
