using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
<<<<<<< HEAD
using System.Runtime.Intrinsics.Arm;
=======
using MyWebApi;
>>>>>>> a822170 (Refactor project into layered architecture)


// For more informati on on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
<<<<<<< HEAD
        static string filePath = "Users.txt";
        // GET: api/<Users>
=======
        IUserServices userServices;
        
        public UsersController(IUserServices userServices)
        {
           this.userServices= userServices; 
        }

>>>>>>> a822170 (Refactor project into layered architecture)
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "esty", "miri" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
<<<<<<< HEAD
               

                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string? currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.id == id)
                            return CreatedAtAction(nameof(Get), new { id = user.id },user);
                }
            } 

=======
            User user= userServices.Get(id);
            if(user!=null)
                return Ok(user);
>>>>>>> a822170 (Refactor project into layered architecture)
            return NotFound();
        }        
        
        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userServices.Post(user);
            return CreatedAtAction(nameof(Get), new { id = user.id },user);
        }


        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] loguser loginUser)
        {
           User logUser = userServices.Post(loginUser);
            if(logUser!=null)
                return Ok(logUser);
            return NoContent();
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] User userToUpdate)
        {
<<<<<<< HEAD
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
                        textToReplace = currentUserInFile;
                }
            }
            
                if(textToReplace != string.Empty)
                {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                }
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


            
        [HttpPost("validPass")]
        // public ActionResult<User> PostLog([FromBody] loguser loginUser)
        public ActionResult<User> Post([FromBody] string pass )
        {
            int s=Zxcvbn.Core.EvaluatePassword(pass).Score;
            return Ok(s);
        }
=======
            userServices.Put(id,userToUpdate);
        }

>>>>>>> a822170 (Refactor project into layered architecture)
    }
}
