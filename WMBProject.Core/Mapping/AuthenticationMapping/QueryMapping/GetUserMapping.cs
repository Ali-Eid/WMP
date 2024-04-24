using System;
using AutoMapper;
using WMBProject.Core.Features.Authentication.Queries.Responses;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationProfile : Profile
    {
        void GetUserMapping()
        {
            CreateMap<User, GetUserResponse>();
        }
    }
}

