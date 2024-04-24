using System;
using AutoMapper;
using WMBProject.Core.Features.Authentication.Commands.Models;

namespace WMBProject.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            RegisterUserMapping();
            GetUserMapping();
        }
    }
}

