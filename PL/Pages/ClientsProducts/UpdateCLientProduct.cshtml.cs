using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.ClientsProducts
{
    public class UpdateCLientProductModel : PageModel
    {
        private readonly ClientProductService _clientProductService;

        public UpdateCLientProductModel( ClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        [BindProperty]
        public ClientProductUpdateDto ClientProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var clientProduct = await _clientProductService.GetClientProductById(id);

            if (clientProduct == null)
            {
                return NotFound();
            }

            ClientProduct = new ClientProductUpdateDto
            {
               
               ClientId =clientProduct.ClientId,
               ProductId= clientProduct.ProductId,
               StartDate=ClientProduct.StartDate,
               EndDate=ClientProduct.EndDate,
               License=ClientProduct.License,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientProductService.UpdateClientProduct(id, ClientProduct);
            return RedirectToPage("clientsProducts");
        }

    }
}

    

