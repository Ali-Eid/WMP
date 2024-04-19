using System;
using Microsoft.EntityFrameworkCore;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;

namespace WMBProject.Service.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepositoryAsync<Order> _orderRepository;

        public OrderService(IGenericRepositoryAsync<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(Order order)
        {
           await _orderRepository.AddAsync(order);
        }

        public async Task<List<Order>> GetOrdersListAsync()
        {
            return await _orderRepository.GetTableNoTracking().Include(x => x.Invoice).Include(x => x.Song).ThenInclude(x=>x.Artist).Include(x=>x.Song).ThenInclude(x=>x.Type).ToListAsync();
        }
    }
}

