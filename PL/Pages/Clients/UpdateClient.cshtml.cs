using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Clients
{
    public class UpdateClientModel : PageModel
    {
       private readonly ClientService _clientService;

        public UpdateClientModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientUpdateDto Client { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var client = await _clientService.GetClientDetailsById(id);

            if (client == null)
            {
                return NotFound();
            }

            Client = new ClientUpdateDto
            {
                Name = client.Name,
                Class = client.Class,
                State = client.State,
            };

            return Page();
        }

        public async Task<IActionResult> OnPosttAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientService.UpdateClient(id, Client);
            return RedirectToPage("clients");
        }
    
}
}
