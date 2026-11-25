using Entities.Models;

namespace Repositorys
{
    public interface IOrderRepository
    {
        Task<Order> PostOrder(Order order);
        Task<Order> GetOrderById(int id);

    }
}