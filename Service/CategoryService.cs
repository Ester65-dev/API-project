using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await repository.GetCategory();
        }
    }
}
