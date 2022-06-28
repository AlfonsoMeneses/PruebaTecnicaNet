using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNet.Contract.Contracts;

namespace PruebaTecnicaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetProductsByName(string name)
        {
            try
            {
                return Ok(_productService.GetProducts(name));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
