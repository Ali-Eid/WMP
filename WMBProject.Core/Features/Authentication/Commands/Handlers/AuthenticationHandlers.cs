using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Authentication.Commands.Models;
using WMBProject.Core.Features.Authentication.Commands.Responses;
using WMBProject.Data.Entities;
using WMBProject.Service.Authentications;

namespace WMBProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationHandlers : ResponseHandler, IRequestHandler<RegisterUserCommand, Response<AuthUserResponse>>,
                                                           IRequestHandler<LoginUserCommand, Response<AuthUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IAuthenticationService _authenticationService;
        public AuthenticationHandlers(SignInManager<User> signInManager,IMapper mapper, UserManager<User> userManager, IAuthenticationService authenticationService)
        {
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<AuthUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //if email exist
          var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null) return BadRequest<AuthUserResponse>("The email is exist");
            //if username exist
            var userByUsername = await _userManager.FindByNameAsync(request.Username);
            if (userByUsername != null) return BadRequest<AuthUserResponse>("The username is exist");

            //mapping
            var identityUser = _mapper.Map<User>(request);

            //create
            var createResult = await _userManager.CreateAsync(identityUser,request.Password);

            //Failed
            if (!createResult.Succeeded) return BadRequest<AuthUserResponse>(createResult.Errors?.FirstOrDefault().Description ?? "Failed to create new user");
            var accessToken = await _authenticationService.GenerateJWTToken(identityUser);
            bool isAdmin = (identityUser.Id == 1 || identityUser.Email == "admin@gmail.com");

            return Success(new AuthUserResponse() { Token = accessToken , isAdmin = isAdmin});
        }

        public async Task<Response<AuthUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return BadRequest<AuthUserResponse>("The email is not exist");

            var signinResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);

            if (!signinResult.Succeeded) return BadRequest<AuthUserResponse>("Wrong username or password");

            var accessToken = await _authenticationService.GenerateJWTToken(user);
            bool isAdmin = (user.Id == 1 || user.Email == "admin@gmail.com");
            return Success(new AuthUserResponse() { Token = accessToken, isAdmin = isAdmin });

        }
    }
}

