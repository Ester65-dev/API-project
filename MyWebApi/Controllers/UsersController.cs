using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
using System.Runtime.Intrinsics.Arm;
using MyWebApi;


// For more informati on on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static string filePath = "Users.txt";
        // GET: api/<Users>
        IUserServices userServices;
        
        public UsersController(IUserServices userServices)
        {
           this.userServices= userServices; 
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "esty", "miri" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user= userServices.Get(id);
            if(user!=null)
                return Ok(user);
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
            userServices.Put(id, userToUpdate);

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
      

    }
}
