using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        estyUsersContext _dbContext;
        public OrderRepository(estyUsersContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Order> PostOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }


    }
}
