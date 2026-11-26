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
        IConfiguration configuration;
        IpassServise IpassServise;
        private readonly ILogger<UsersController> logger;


        public UsersController(IUserServices userServices, IConfiguration configuration,IpassServise ipassServise, ILogger<UsersController> logger)
        {
            this.userServices = userServices;
            this.configuration = configuration;
            this.IpassServise= ipassServise;
            this.logger= logger;
            logger.LogInformation($"new user entered");
        }



        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userServices.Get();
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
           if(userServices.Get(id) != null)
            {
                return await userServices.Get(id);
            }
            return NoContent();
        }        
        
        // POST api/<Users>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user, ILogger<UsersController> _loger)
        {
            logger.LogInformation($"new user signin with name: {user.Firstname} and password: {user.Password}");
            int strengOfPassword = IpassServise.Post(user.Password);
            if (strengOfPassword <= configuration.GetValue<int>("passwordStrong", 2))
                return BadRequest("not a strong password");
            try
            {
                user = await userServices.Post(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        public async  Task<ActionResult<User>> Post([FromBody] loguser loginUser)
        {
           User logUser = await userServices.Post(loginUser);
            if (logUser != null)
            {
                logger.LogInformation("user sucssesfuly log in");
                return Ok(logUser);
            }
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
