using System;
using FluentValidation;
using WMBProject.Core.Features.Invoices.Command.Models;

namespace WMBProject.Core.Features.Invoices.Command.Validators
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceValidator()
        {
            ApplyValidatorRules();
            ApplyCustomeValidatorRules();
        }

        void ApplyValidatorRules()
        {
            RuleFor(x => x.SongsIds).NotEmpty().NotNull();
            RuleFor(x => x.CreditCard).NotEmpty().NotNull().MinimumLength(14).MaximumLength(18);

        }
        void ApplyCustomeValidatorRules()
        {

        }
    }
}

