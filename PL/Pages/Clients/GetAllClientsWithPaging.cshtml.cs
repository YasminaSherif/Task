using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Clients
{
    public class GetAllClientsWithPagingModel : PageModel
    {
        private readonly ClientService _clientService;

        public GetAllClientsWithPagingModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        public List<ClientDto> Clients { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            const int pageSize = 3;  
            var clientsResult = await _clientService.GetAllClientsWithPaging(pageNumber, pageSize);

            Clients = clientsResult.ToList();
            CurrentPage =pageNumber;
            TotalPages = pageSize;
        }
    }
}
