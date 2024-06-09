using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class GetAllProductsModel : PageModel
    {
        private readonly ProductService _productService;

        public GetAllProductsModel(ProductService productService)
        {
            _productService = productService;
        }

        public List<ProductDto>? Products { get; set; } = new List<ProductDto>();

        public async Task OnGetAsync()
        {

            Products = await _productService.GetAllProducts();
        }
    }
}
