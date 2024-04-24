using System;
using FluentValidation;
using WMBProject.Core.Features.Orders.Command.Models;

namespace WMBProject.Core.Features.Orders.Command.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            ApplyValidationRules();
            ApplyCustomerValidationRules();
        }

        void ApplyValidationRules() {
            RuleFor(x => x.SongsIds).NotNull().NotEmpty();
            RuleFor(x => x.InvoiceId).NotNull().NotEmpty();
        }

        void ApplyCustomerValidationRules() { }

    }
}

