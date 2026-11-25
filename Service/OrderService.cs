using Entities.Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository repository;

        public OrderService(IOrderRepository OrderRepository)
        {
            this.repository = OrderRepository;
        }



        public async Task<Order> Post(Order order)
        {
            return await repository.PostOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await repository.GetOrderById(id);
        }

    }
}
