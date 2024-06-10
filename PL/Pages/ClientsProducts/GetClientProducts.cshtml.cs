using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.ClientsProducts
{
    public class GetClientProductsModel : PageModel
    {
        private readonly ClientProductService _clientProductService;

        public GetClientProductsModel(ClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        public List<ClientProductDto>? ClientProducts { get; set; } = new List<ClientProductDto>();

        public async Task OnGetAsync()
        {
            ClientProducts = await _clientProductService.GetAllClientProducts();
        }
    }
}
