using DTO.Client;
using DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace PL.Services
{
    public class ProductService : HttpServices
    {
        public ProductService(HttpClient httpClient) : base(httpClient) { }


        public async Task<ProductDto?> CreateProduct(ProductCreateDto product)
        {
            return await Post<ProductDto?, ProductCreateDto>("https://localhost:7083/api/Product", product);
        }


        public async Task DeleteProduct(string id)
        {
            await Delete($"https://localhost:7083/Api/Prpduct/{id}");
        }


        public async Task<List<ProductDto>?> GetAllProducts()
        {
            return await Get<List<ProductDto>?>("https://localhost:7083/api/Product");
        }

        public async Task<List<ProductDto>> GetAllProductsWithPaging(int pageNumber, int pageSize)
        {
            return await Get<List<ProductDto>>($"https://localhost:7083/api/Product/paging?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ProductDto> GetProductById(string id)
        {
            return await Get<ProductDto>($"https://localhost:7083/api/Product/{id}");
        }

        public async Task<ProductDto> UpdateProduct(string id, productUpdateDto product)
        {
            return await Put<ProductDto, productUpdateDto>($"https://localhost:7083/api/Client/{id}", product);
        }


    }
}
