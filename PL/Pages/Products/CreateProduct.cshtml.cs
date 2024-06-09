using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        private readonly ProductService _productService;

        public CreateProductModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductCreateDto product { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _productService.CreateProduct(product);
                return RedirectToPage("products");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return Page();
            }
        }

    }
}
