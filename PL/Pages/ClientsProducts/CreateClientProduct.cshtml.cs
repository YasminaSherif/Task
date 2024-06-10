using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.ClientsProducts
{
    public class CreateClientProductModel : PageModel
    {
        private readonly ClientProductService _clientProductService;

        public CreateClientProductModel(ClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        [BindProperty]
        public ClientProductCreateDto clientProductDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _clientProductService.CreateClientProduct(clientProductDto);
                return RedirectToPage("clientsProducts");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return Page();
            }
        }

    }
}

