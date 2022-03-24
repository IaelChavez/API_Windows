using API_Windows.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Windows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: <ProductController>
        [HttpGet]
        public List<ProductModel> GetAll()
        {
            return new ProductModel().GetAll();
            
        }

        // GET <ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Hola, el id envieado es {id}";

        }

        // POST <ProductController>
        [HttpPost]
        public void Post([FromBody] ProductModel model)
        {
            new ProductModel().Add(model);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public void Put([FromBody] ProductModel model)
        {
            new ProductModel().Update(model);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ProductModel().Delete(id);
        }
    }
}
