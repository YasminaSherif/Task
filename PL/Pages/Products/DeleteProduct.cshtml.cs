using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class DeleteProductModel : PageModel
    {
        private readonly ProductService _productService;

        public DeleteProductModel( ProductService productService)
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

                return Page();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            try

    {
                await _productService.DeleteProduct(id);
            }
	catch (Exception e)

    {

                ModelState.AddModelError(string.Empty, e.Message);

                return Page();
            }
            return RedirectToPage("GetAllProducts");
        }
    }
}
