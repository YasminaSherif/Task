using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Clients
{
    public class CreateClientModel : PageModel
    {
        private readonly ClientService _clientService;

        public CreateClientModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientCreateDto Client { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _clientService.CreateClient(Client);
                return RedirectToPage("Clients");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return Page();
            }
        }

    }
}