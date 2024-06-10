using DTO.ClientProduct;
using DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace PL.Services
{
    public class ClientProductService : HttpServices
    {
        public ClientProductService(HttpClient httpClient) : base(httpClient)
        {

        }
        public async Task<List<ClientProductDto>> GetAllClientProducts()
        {
            return await Get<List<ClientProductDto>>("https://localhost:7083/api/ClientProduct");
        }
        public async Task<ClientProductDto> CreateClientProduct(ClientProductCreateDto clientProduct)
        {
            return await Post<ClientProductDto, ClientProductCreateDto>("https://localhost:7083/api/ClientProduct", clientProduct);
        }

        public async Task<ClientProductDetailesDto> GetClientProductById(string id)
        {
            return await Get<ClientProductDetailesDto>($"https://localhost:7083/api/ClientProduct/{id}");
        }


        public async Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdateDto clientProduct)
        {
            return await Put<ClientProductDto?, ClientProductUpdateDto>($"https://localhost:7083/api/ClientProduct/{id}", clientProduct);
        }

        public async Task DeleteClientProduct(string id)
        {
            await Delete($"https://localhost:7083/api/ClientProduct/{id}");
        }
    }
}
