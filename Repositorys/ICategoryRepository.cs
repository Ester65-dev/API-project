using Entities.Models;

namespace Repositorys
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
    }
}