using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Clients
{
    public class GetAllClientsModel : PageModel
    {
        private readonly ClientService _clientService;

        public GetAllClientsModel(ClientService clientService)
        {
            _clientService = clientService;
        }
        
        public List<ClientDto> Clients { get; set; }= new List<ClientDto>();

        public async Task OnGetAsync()
        {
            Clients = await _clientService.GetAllClients();
        }
    }
}
