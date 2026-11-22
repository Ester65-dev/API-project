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
        static readonly string filePath = "E:/3/Repositorys/Users.txt";

        User user = new User();
        loguser loguser;

        public string Get()
        {
            return filePath;
        }

                      
        public User Get(int id)
        {


            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        return user;

                }
            }

            return null;
        }


        public User Post(User user)
        {

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);

            return user;

        }
                     

        public User Post(loguser loginUser)

        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password == loginUser.password)
                        return user;
                }
            }
            return null;
        }


        public void Put(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == userToUpdate.id)
                    {
                        textToReplace = currentUserInFile;
                        break;
                    }
                }
            }
                        
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }
        }


    }
}

