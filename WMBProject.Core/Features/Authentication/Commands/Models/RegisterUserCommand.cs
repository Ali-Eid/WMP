using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Authentication.Commands.Responses;

namespace WMBProject.Core.Features.Authentication.Commands.Models
{
    public class RegisterUserCommand :IRequest<Response<AuthUserResponse>>
    {
        public required string Username { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        public string? FirstName { get; set; } = null;

        public string? LastName { get; set; } = null;

        public string? Address { get; set; }

    }
}

