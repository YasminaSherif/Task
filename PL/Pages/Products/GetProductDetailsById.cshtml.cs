using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class GetProductDetailsByIdModel : PageModel
    {
        private readonly ProductService _productService;

        public GetProductDetailsByIdModel(ProductService productService)
        {
            _productService = productService;
        }

        public ProductDto product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {

            product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Page();

            ;
        }
    }
}

