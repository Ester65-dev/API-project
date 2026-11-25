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


        public async Task<(List<Product> Items, int totalcount)> GetProductsAsync(int position,int skip, string? desc ,int? minPrice, int? maxPrice, int?[] categoryId)
        {
            var query = _dbContext.Products.Where(product => (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryId.Length == 0) ? (true) : (categoryId.Contains(product.CategoryId)))
            ).OrderBy(Product => Product.Price);

            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.Skip((position-1)*skip).Take(skip).Include(product=>product.Category).ToListAsync();
            var total = await query.CountAsync();
            return (products, total);
        }


    }
}
