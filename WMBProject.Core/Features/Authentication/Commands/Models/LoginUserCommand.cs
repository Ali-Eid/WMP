using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Authentication.Commands.Responses;

namespace WMBProject.Core.Features.Authentication.Commands.Models
{
    public class LoginUserCommand : IRequest<Response<AuthUserResponse>>
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}

