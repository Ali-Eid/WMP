using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Orders.Query.Responses;

namespace WMBProject.Core.Features.Orders.Query.Models
{
    public class GetOrdersListQuery : IRequest<Response<List<GetOrdersListResponse>>>
    {
    }
}

