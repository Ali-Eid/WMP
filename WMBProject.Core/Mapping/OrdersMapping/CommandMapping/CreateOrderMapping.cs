using System;
using AutoMapper;
using WMBProject.Core.Features.Orders.Command.Models;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.OrdersMapping
{
    
    public partial class OrderProfile : Profile
    {
       void CreateOrderMapping()
        {
            CreateMap<CreateOrderCommand, Order>();
        }
    }
}

