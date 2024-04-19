using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Orders.Command.Models;
using WMBProject.Data.Entities;
using WMBProject.Service.Orders;

namespace WMBProject.Core.Features.Orders.Command.Handlers
{
    public class OrderCommandHandler :ResponseHandler, IRequestHandler<CreateOrderCommand , Response<string>>
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderMapping = _mapper.Map<Order>(request);
            await _orderService.CreateOrder(orderMapping);
            return Success("Created order successfully");
        }
    }
}

