using Repositorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace Service
{
    public class UserServices : IUserServices
    {
        IUserRepository repository;
       
        public UserServices(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public string Get()
        {
            return repository.Get();
        }

        public User Get(int id)
        {
            return repository.Get(id);
        }


        public User Post(User user)
        {
            return repository.Post(user);
        }


        public User Post(loguser loginUser)

        {
            return repository.Post(loginUser);
        }


        public void Put(int id, User userToUpdate)
        {
            repository.Put(id, userToUpdate);

        }
    }
}

