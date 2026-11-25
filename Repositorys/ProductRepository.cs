using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorys
{
    public class ProductRepository : IProductRepository
    {

        estyUsersContext _dbContext;
        public ProductRepository(estyUsersContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }


    }
}
