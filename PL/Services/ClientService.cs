using DTO.Client;

namespace PL.Services
{
    public class ClientService : HttpServices
    {

        public ClientService(HttpClient httpClient) : base(httpClient)
        {

        }

        public Task<List<ClientDto>> GetAllClients()
        {
            return Get<List<ClientDto>>("https://localhost:7083/api/Client");
        }

        public Task<ClientDto> CreateClient(ClientCreateDto client)
        {
            return Post<ClientDto, ClientCreateDto>("https://localhost:7083/api/Client", client);
        }


        public Task<ClientDto> UpdateClient(string id, ClientUpdateDto client)
        {
            return Put<ClientDto, ClientUpdateDto>($"https://localhost:7083/api/Client/{id}", client);
        }

        public Task DeleteClient(string id)
        {
            return Delete($"https://localhost:7083/api/Client/{id}");
        }

        public Task<ClientWithDtailesDto> GetClientDetailsById(string id)
        {
            return Get<ClientWithDtailesDto>($"https://localhost:7083/api/Client/{id}");
        }

        public Task<IEnumerable<ClientDto>> GetAllClientsWithPaging(int pageNumber, int pageSize)
        {
            return Get<IEnumerable<ClientDto>>($"https://localhost:7083/api/Client/paging?pageNumber={pageNumber}&pageSize={pageSize}");
        }
    }



}