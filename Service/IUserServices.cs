using Entities.Models;

namespace Service
{
    public interface IUserServices
    {
       
         Task<User> Get(int id);
         Task<User> Post(loguser loginUser);
         Task<User> Post(User user);
         Task Put(int id, User userToUpdate);
    }
}