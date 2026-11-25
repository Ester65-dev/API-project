using Entities.Models;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategory();
    }
}