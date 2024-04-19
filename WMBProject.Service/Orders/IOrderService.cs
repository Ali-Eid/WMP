using System;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;

namespace WMBProject.Service.Orders
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrdersListAsync();

        public Task CreateOrder(Order order);

    }
}

