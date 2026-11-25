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

        public async Task<IEnumerable<Product>> Get()
        {
            return await repository.GetProductsAsync();
        }

    }
}
