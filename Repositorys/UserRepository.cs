using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json;
//using Entities;


namespace Repositorys
{
    public class UserRepository : IUserRepository
    {
        estyUsersContext _dbContext;
        public UserRepository(estyUsersContext estyUsersContext)
        {
            _dbContext=estyUsersContext;
        }
       

        //User user = new User();
        loguser loguser;

        public async Task<User> Get(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }


        public async Task<User> Post(User user)
        {
           await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
            return user;

        }


        public async Task<User> Post(loguser loginUser)
        {
           return await _dbContext.Users.Where(user=>user.Email==loginUser.email && user.Password == loginUser.password).FirstOrDefaultAsync();
        }


        public async Task Put(int id, User userToUpdate)
        {
            userToUpdate.Id = id;
            _dbContext.Users.Update(userToUpdate); 
            await _dbContext.SaveChangesAsync();
        }


    }
}

