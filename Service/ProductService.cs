using Entities.Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProductService : IProductService
    {
        IProductRepository repository;

        public ProductService(IProductRepository ProductRepository)
        {
            this.repository = ProductRepository;
        }

        public async Task<(List<Product> Items, int totalcount)> GetProductsAsync(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryId)
        {
            return await repository.GetProductsAsync( position,  skip,  desc,  minPrice,  maxPrice,  categoryId);
        }

    }
}
