using DTO.ClientProduct;
using Microsoft.AspNetCore.Mvc;

namespace PL.Services
{
    public class ClientProductService:HttpServices
    {
        ClientProductService(HttpClient httpClient):base(httpClient) { }

        public async Task<ClientProductDto> CreateClientProduct(ClientProductCreateDto clientProduct)
        {
            return await Post<ClientProductDto,ClientProductCreateDto>("Api/ClientProduct",clientProduct);
        }

        public async Task<ClientProductDto> GetClientProductById(string id)
        {
            return await Get<ClientProductDto>($"Api/ClientProduct/{id}");
        }


        public async Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdate clientProduct)
        {
            return await Put<ClientProductDto?,ClientProductUpdate> ($"Api/ClientProduct/{id}", clientProduct);
        }

        public async Task DeleteClientProduct(string id)
        {
          await Delete($"Api/ClientProduct/{id}");
        }
    }
}
