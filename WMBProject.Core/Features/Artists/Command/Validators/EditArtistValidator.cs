using System;
using FluentValidation;
using WMBProject.Core.Features.Artists.Command.Models;

namespace WMBProject.Core.Features.Artists.Command.Validators
{
    public class EditArtistValidator : AbstractValidator<EditArtisCommand>
    {
        public EditArtistValidator()
        {
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

        void ApplyValidationRules() {
            RuleFor(x => x.FName)
                 .NotNull().WithMessage("First name must not be null")
                 .NotEmpty().WithMessage("First name must not be empty")
                 .MaximumLength(50).WithMessage("First name must not be more than 50 characters");

            RuleFor(x => x.LName)
               .NotNull().WithMessage("Last name must not be null")
               .NotEmpty().WithMessage("Last name must not be empty")
               .MaximumLength(50).WithMessage("Last name must not be more than 50 characters");
        }

        void ApplyCustomeValidationRules() { }
    }
}

