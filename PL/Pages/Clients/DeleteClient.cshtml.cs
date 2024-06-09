using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Clients
{
    public class DeleteClientModel : PageModel
    {
        private readonly ClientService _clientService;

        public DeleteClientModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientWithDtailesDto Client { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Client = await _clientService.GetClientDetailsById(id);

            if (Client == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            await _clientService.DeleteClient(id);
            return RedirectToPage("GetAllClients");
        }
    }
}
