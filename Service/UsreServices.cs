using Entities.Models;
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

        public async Task<User> Get(int id)
        {
            return await repository.Get(id);
        }

        public async Task<IEnumerable<User>> Get()
        {
           return await repository.Get();
        }

        public async Task<User> Post(User user)
        {
            return await repository.Post(user);
        }


        public async Task<User> Post(loguser loginUser)

        {
            return await repository.Post(loginUser);
        }


        public async Task Put(int id, User userToUpdate)
        {
            await repository.Put(id, userToUpdate);

        }
    }
}

