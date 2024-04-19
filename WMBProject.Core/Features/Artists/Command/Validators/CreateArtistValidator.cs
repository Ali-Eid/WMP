using System;
using FluentValidation;
using WMBProject.Core.Features.Artists.Command.Models;

namespace WMBProject.Core.Features.Artists.Command.Validators
{
    public class CreateArtistValidator : AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistValidator()
        {
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FName)
                .NotNull().WithMessage("First name must not be null")
                .NotEmpty().WithMessage("First name must not be empty")
                .MaximumLength(50).WithMessage("First name must not be more than 50 characters");

            RuleFor(x => x.LName)
               .NotNull().WithMessage("Last name must not be null")
               .NotEmpty().WithMessage("Last name must not be empty")
               .MaximumLength(50).WithMessage("Last name must not be more than 50 characters");


        }
        public void ApplyCustomeValidationRules()
        {
            //for make methods in service for check if name is exist or any information and call it in this method to validated 
            //RuleFor(x=>x.FName).MustAsync(async (Key,CancellationToken) => {
            //    return await Task.FromResult(true);
            //});

        }

    }
}

