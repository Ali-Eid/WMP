using System;
using System.IdentityModel.Tokens.Jwt;
using WMBProject.Data.Entities;

namespace WMBProject.Service.Authentications
{
    public interface IAuthenticationService
    {
        public Task<string> GenerateJWTToken(User user);

        public Task<User> GetUser();

    }
}

