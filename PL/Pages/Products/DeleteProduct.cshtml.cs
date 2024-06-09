using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;
using System;
using System.Threading.Tasks;

namespace PL.Pages.Products
{
    public class deleteProductModel : PageModel
    {
        private readonly ProductService _productService;

        public deleteProductModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductDto product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                product = await _productService.GetProductById(id);

                if (product == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (product == null || product.Id == null)
                {
                    return BadRequest("Product is not set.");
                }

                await _productService.DeleteProduct(product.Id);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return Page();
            }

            return RedirectToPage("GetAllProducts");
        }
    }
}
