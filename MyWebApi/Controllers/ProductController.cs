using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {



        IProductService ProductService;

        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

      

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<(List<Product> Items, int totalcount)>> GetProductsAsync(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryId)
        {
            (List<Product> Items, int totalcount) product =await ProductService.GetProductsAsync( position,  skip,   desc,   minPrice,   maxPrice,  categoryId);
            if (product.Items != null)
                return Ok(product);
            return NotFound();
        }





        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            if (ProductService.GetById(id))
                return await ProductService.GetById(id);
            return NoContent();
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
