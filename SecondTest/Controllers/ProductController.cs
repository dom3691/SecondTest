using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondTest.Services.Interfaces;

namespace SecondTest.Controllers
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


        [HttpGet()]
        public async Task<IActionResult> GetProductById(Guid Id)
        {
            var result = await _productService.GetProductByid(Id);
            return Ok(result);

        }
    }
}
