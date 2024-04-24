using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Authentication.Queries.Models;
using WMBProject.Core.Features.Authentication.Queries.Responses;
using WMBProject.Data.Entities;
using WMBProject.Service.Authentications;

namespace WMBProject.Core.Features.Authentication.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler , IRequestHandler<GetUserQuery , Response<GetUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public UserQueryHandler(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetUser();
            var userMapping = _mapper.Map<GetUserResponse>(user);
            return Success(userMapping);
        }
    }
}

