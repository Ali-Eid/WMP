using System;
using FluentValidation;
using WMBProject.Core.Features.Songs.Command.Models;

namespace WMBProject.Core.Features.Songs.Command.Validators
{
    public class CreateSongValidator : AbstractValidator<CreateSongCommand>
    {
        public CreateSongValidator()
        {
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }

       public void ApplyValidationRules()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Song title must not be null")
                .NotEmpty().WithMessage("Song title must not be empty")
                .MaximumLength(50).WithMessage("Song title must not be more than 50 characters");

        }
        public void ApplyCustomeValidationRules()
        {

        }
    }
}

