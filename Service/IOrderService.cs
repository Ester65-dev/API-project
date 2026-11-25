using Entities.Models;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> Post(Order order);
        Task<Order> GetOrderById(int id);
    }
}