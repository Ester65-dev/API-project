using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
using MyWebApi;
using Entities.Models;


// For more informati on on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
        public async Task<ActionResult<User>> Get(int id)
        {
            User user= await userServices.Get(id);
            if(user!=null)
                return Ok(user);
            return NotFound();
        }        
        
        // POST api/<Users>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            await userServices.Post(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id},user);
        }


        [HttpPost("login")]
        public async  Task<ActionResult<User>> Post([FromBody] loguser loginUser)
        {
           User logUser = await userServices.Post(loginUser);
            if(logUser!=null)
                return Ok(logUser);
            return NoContent();
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] User userToUpdate)
        {
            passServise passServise = new passServise();
            int strangthOfPassword= passServise.Post(userToUpdate.Password);
            if(strangthOfPassword<3)
                return BadRequest();
            await userServices.Put(id,userToUpdate);
            return Ok();
        }

    }
}
