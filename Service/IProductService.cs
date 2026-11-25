using Entities.Models;

namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
    }
}