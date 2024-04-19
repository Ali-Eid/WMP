using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Orders.Query.Models;
using WMBProject.Core.Features.Orders.Query.Responses;
using WMBProject.Service.Orders;

namespace WMBProject.Core.Features.Orders.Query.Handlers
{
    public class OrderQueryHandler :ResponseHandler, IRequestHandler<GetOrdersListQuery , Response<List<GetOrdersListResponse>>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderQueryHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetOrdersListResponse>>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrdersListAsync();
            var ordersMapping = _mapper.Map<List<GetOrdersListResponse>>(orders);
            return Success(ordersMapping);
        }
    }
}

