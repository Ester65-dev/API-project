using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassController : ControllerBase
    {
        IpassServise passServise;
        public PassController(IpassServise passServise)
        {
            this.passServise = passServise;
        }

        // GET: api/<PassController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PassController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      

        [HttpPost]
        // public ActionResult<User> PostLog([FromBody] loguser loginUser)
        public IActionResult Post([FromBody] string pass)
        {
            return Ok(passServise.Post(pass));
        }

        // PUT api/<PassController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
