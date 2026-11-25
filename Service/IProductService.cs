using Entities.Models;

namespace Service
{
    public interface IProductService
    {
        Task<(List<Product> Items, int totalcount)> GetProductsAsync(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryId);

    }
}