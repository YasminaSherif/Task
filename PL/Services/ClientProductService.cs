using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;

namespace PL.Services
{
    public class ClientProductService:HttpServices
    {
       public ClientProductService(HttpClient httpClient):base(httpClient) {

        }

        public async Task<ClientProductDto> CreateClientProduct(ClientProductCreateDto clientProduct)
        {
            return await Post<ClientProductDto,ClientProductCreateDto>("https://localhost:7083/api/ClientProduct", clientProduct);
        }

        public async Task<ClientProductDto> GetClientProductById(string id)
        {
            return await Get<ClientProductDto>($"https://localhost:7083/api/ClientProduct/{id}");
        }


        public async Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdate clientProduct)
        {
            return await Put<ClientProductDto?,ClientProductUpdate> ($"https://localhost:7083/api/ClientProduct/{id}", clientProduct);
        }

        public async Task DeleteClientProduct(string id)
        {
          await Delete($"https://localhost:7083/api/ClientProduct/{id}");
        }
    }
}
