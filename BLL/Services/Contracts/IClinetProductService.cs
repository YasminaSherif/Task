using DAL.Models;
using DTO.Client;
using DTO.ClientProduct;
using DTO.Product;

namespace BLL.Services.Contracts
{
    public interface IClinetProductService
    {
        Task<ClientProductDto> CreateClientProduct(ClientProductCreateDto model);
        Task<bool> DeleteClientProduct(string id);
        Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdateDto model);
        Task<List<ClientProductDto>?> GetAllClientProducts();
        Task<ClientProductDetailesDto?> GetClientProductDetailsById(string id);
    }

}
