namespace Repositorys
{
    public interface IUserRepository
    {
        string Get();
        User Get(int id);
        User Post(loguser loginUser);
        User Post(User user);
        void Put(int id, User userToUpdate);
    }
}