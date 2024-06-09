using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.ClientsProducts
{
    public class GetCLientProductByIdModel : PageModel
    {
        private readonly ClientProductService _clientProductService;

        public GetCLientProductByIdModel(ClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

       public  ClientProductDto ClientProduct { get;set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {


            
                ClientProduct = await _clientProductService.GetClientProductById(id);
            
           

            if (ClientProduct == null)
            {
                return NotFound();
            }
            return Page();

            ;
        }
    }
}