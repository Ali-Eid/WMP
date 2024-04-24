using System;
namespace WMBProject.Core.Features.Authentication.Commands.Responses
{
    public class AuthUserResponse
    {
        public string Token { get; set; }

        public bool isAdmin { get; set; }
    }
}

