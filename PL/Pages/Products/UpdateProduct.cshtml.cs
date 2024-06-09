using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class updateProductModel : PageModel
    {
        private readonly ProductService _productService;

        public updateProductModel(ProductService productService)
        {
            _productService = productService;
        }
        [BindProperty]
        public productUpdateDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            Product = new productUpdateDto
            {
                Name = product.Name,
                Description = product.Description,
                IsActive=product.IsActive,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.UpdateProduct(id, Product);
            return RedirectToPage("products");
        }

    }
}
