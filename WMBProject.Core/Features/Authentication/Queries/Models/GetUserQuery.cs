using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Authentication.Queries.Responses;

namespace WMBProject.Core.Features.Authentication.Queries.Models
{
    public class GetUserQuery : IRequest<Response<GetUserResponse>>
    {
        
    }
}

