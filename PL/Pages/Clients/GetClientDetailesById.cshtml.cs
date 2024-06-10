using DTO.Client;
using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Clients
{
    public class GetClientDetailesByIdcshtmlModel : PageModel
    {

        private readonly ClientService _clientService;

        public GetClientDetailesByIdcshtmlModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        public ClientWithDtailesDto Client { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {


            Client = await _clientService.GetClientDetailsById(id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();

            ;
        }
    }
}

