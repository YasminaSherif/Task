using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PL.Services;

namespace PL.Pages.Products
{
    public class GetAllProductsWithPagingModel : PageModel
    {
        private readonly ProductService _productService;

        public GetAllProductsWithPagingModel(ProductService productService)
        {
            _productService = productService;
        }

        public List<ProductDto> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            const int pageSize = 3;
            var productsResult = await _productService.GetAllProductsWithPaging(pageNumber, pageSize);

            Products = productsResult;
            CurrentPage = pageNumber;
            TotalPages = pageSize;
        }
    }
}





