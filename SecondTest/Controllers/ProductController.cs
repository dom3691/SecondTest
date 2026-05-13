using Microsoft.AspNetCore.Mvc;
using SecondTest.Services.Interfaces;
using Serilog;
using System.Diagnostics;

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
            try
            {
                var result = await _productService.GetProductByid(Id);

                if (result is null)
                {
                    var response = "Product not found.";

                    Log.Warning(
                        "Product lookup completed but no product was found for product id {ProductId}. Response: {Response}",
                        Id,
                        response);

                    return NotFound(response);
                }

                Log.Information(
                    "Product lookup completed successfully for product id {ProductId}. Response: {@Response}",
                    Id,
                    result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var failureLocation = GetFailureLocation(ex);
                var response = "An error occurred while getting the product.";

                Log.Error(
                    ex,
                    "Product lookup failed for product id {ProductId}. FailingLine: {FailingLine}. Response: {Response}",
                    Id,
                    failureLocation,
                    response);

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        private static string GetFailureLocation(Exception exception)
        {
            var frame = new StackTrace(exception, true).GetFrames()?
                .FirstOrDefault(currentFrame => currentFrame.GetFileLineNumber() > 0);

            if (frame is null)
            {
                return "Line unavailable. Build with debug symbols to include source line numbers.";
            }

            return $"{frame.GetFileName()}:line {frame.GetFileLineNumber()}";
        }
    }
}
