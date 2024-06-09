using DTO.Product;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Controllers
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

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDto product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdProduct = await _productService.CreateProduct(product);
                    return Created(nameof(GetProductById), createdProduct);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);
                if (result)
                {
                    return Ok();
                }
                return NotFound("Product not found");
            }
            catch (Exception e)
            {


                return BadRequest(e.Message);

            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                if (products == null || !products.Any())
                {
                    return NotFound("No products found.");
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllProductsWithPaging(int pageNumber, int pageSize)
        {
            try
            {
                var products = await _productService.GetAllProductsWithPaging(pageNumber, pageSize);
                if (products == null || !products.Any())
                {
                    return NotFound("No products found for the given page.");
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound("Product not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, productUpdateDto product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedProduct = await _productService.UpdateProduct(id, product);
                    if (updatedProduct != null)
                    {
                        return Ok(updatedProduct);
                    }
                    return NotFound("Product not found");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }
    }
}
