using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class UpdateProductModel : PageModel
    {
        private readonly ProductService _productService;

        public UpdateProductModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public productUpdateDto product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var client = await _productService.GetProductById(id);

            if (client == null)
            {
                return NotFound();
            }

            product = new productUpdateDto
            {
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.UpdateProduct(id, product);
            return RedirectToPage("GetAllProducts");
        }

    }
}
