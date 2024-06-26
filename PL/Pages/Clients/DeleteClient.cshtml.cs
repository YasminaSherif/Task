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
            try
            {
                Client = await _clientService.GetClientDetailsById(id);

                if (Client == null)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            try
            {
                await _clientService.DeleteClient(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return Page();

            }
            return RedirectToPage("GetAllClients");
        }
    }
}
