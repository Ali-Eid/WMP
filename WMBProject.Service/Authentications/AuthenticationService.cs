using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WMBProject.Data.Configuration;
using WMBProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using WMBProject.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace WMBProject.Service.Authentications
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> userEntity;
        private readonly UserManager<User> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthenticationService(UserManager<User> userManager, JwtSettings jwtSettings, ApplicationDbContext context , IHttpContextAccessor httpContextAccessor)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _context = context;
            userEntity = context.Set<User>();
            _httpContextAccessor = httpContextAccessor;

        }

        public Task<string> GenerateJWTToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
            };
            var jwtToken = new JwtSecurityToken(
                           _jwtSettings.Issuer,
                           _jwtSettings.Audience,
                           claims,
                           expires: DateTime.Now.AddYears(2),
                           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return Task.FromResult(accessToken);
        }

        public async Task<User> GetUser()
        {
            if (_httpContextAccessor.HttpContext == null)
                return null;
            var authenticateResult = await _httpContextAccessor.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded)
                return null;
            User? customer = null;
            var identifierClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier);
            if (identifierClaim != null && int.TryParse(identifierClaim.Value, out int customerId))
            {
                IQueryable<User> query = userEntity;

                customer = (query.Where(u => u.Id == customerId)).FirstOrDefault();

                //customer = (await _context.FindAsync(u => u.Id == customerId)).FirstOrDefault();
            }
            if (customer == null)
                return null;

            return await _userManager.FindByIdAsync(customer.Id.ToString());
        }
    }
}

