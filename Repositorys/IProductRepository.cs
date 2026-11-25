using Entities.Models;

namespace Repositorys
{
    public interface IProductRepository
    {
        Task<(List<Product> Items, int totalcount)> GetProductsAsync(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryId);

    }
}