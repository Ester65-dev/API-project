using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        estyUsersContext _dbContext;
        public CategoryRepository(estyUsersContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _dbContext.Categories.ToListAsync();
        }

    }
}
