using System;
using AutoMapper;
using WMBProject.Core.Features.Authentication.Commands.Models;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationProfile : Profile
    {
       public void RegisterUserMapping()
        {
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
