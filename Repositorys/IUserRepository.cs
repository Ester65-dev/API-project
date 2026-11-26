using Entities.Models;

namespace Repositorys
{
    public interface IUserRepository
    {
        
     
        Task<User> Get(int id);
        Task<IEnumerable<User>> Get();


        Task<User> Post(loguser loginUser);
        Task<User> Post(User user);
        Task Put(int id, User userToUpdate);
    }
}