global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                var req = await productService.AddProduct(product);
                if (req.IsSuccessful == false)
                {
                    return BadRequest(req);
                }
                else
                {
                    return Ok(req);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var req = await productService.GetProductById(id);
                if (req.IsSuccessful == false)
                {
                    return BadRequest(req);
                }
                else
                {
                    return Ok(req);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var req = await productService.GetAllProducts();
                if (req.Count < 1)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(req);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var req = await productService.DeleteProduct(id);
                if (req.IsSuccessful == false)
                {
                    return BadRequest(req);
                }
                else
                {
                    return Ok(req);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                var req = await productService.UpdateProduct(product);
                if (req.IsSuccessful == false)
                {
                    return BadRequest(req);
                }
                else
                {
                    return Ok(req);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Products")]
        public async Task<IActionResult> UpdateProducts()
        {
            try
            {
                var req = await productService.UpdateProducts();
                if (req.IsSuccessful == false)
                {
                    return BadRequest(req);
                }
                else
                {
                    return Ok(req);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
