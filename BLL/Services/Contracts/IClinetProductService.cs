using BLL.DTO.Client;
using BLL.DTO.ClientProduct;
using BLL.DTO.Product;

namespace BLL.Services.Contracts
{
    public interface IClinetProductService
    {
        Task<ClientProductDto> CreateClientProduct(ClientProductCreateDto model);
        Task<bool> DeleteClientProduct(string id);
        Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdate model);
        Task<ClientProductDto?> GetClientProductById(String id);
    }

}
