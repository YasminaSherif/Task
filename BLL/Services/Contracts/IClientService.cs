using BLL.DTO.Client;
using DAL.Models;

namespace BLL.Services.Contracts
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllClientsWithPaging(int pageNumber, int pageSize);
        Task<List<ClientDto>> GetAllClients();
        Task<ClientWithDtailesDto?> GetClientDetailsById(String id);
        Task<ClientDto> CreateClient(ClientCreateDto model);
        Task<bool> DeleteClient(string id);
        Task<ClientDto?> UpdateClient(string id,ClientDto model);
    }
}
