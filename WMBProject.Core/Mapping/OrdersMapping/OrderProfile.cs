using System;
using AutoMapper;

namespace WMBProject.Core.Mapping.OrdersMapping
{
    public partial class OrderProfile : Profile
    {
        public OrderProfile()
        {
            GetOrdersListMapping();
            CreateOrderMapping();
        }
    }
}

