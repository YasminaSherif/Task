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
            return Get<List<ClientDto>>("api/Client");
        }

        public Task<ClientDto> CreateClient(ClientCreateDto client)
        {
            return Post<ClientDto,ClientCreateDto> ("api/Client", client);
        }


        public Task<ClientDto> UpdateClient(string id, ClientUpdateDto client)
        {
            return Put<ClientDto, ClientUpdateDto>($"api/Client/{id}", client);
        }

        public Task DeleteClient(string id)
        {
            return Delete($"api/Client/{id}");
        }

        public Task<ClientDto> GetClientDetailsById(string id)
        {
            return Get<ClientDto>($"api/Client/{id}");
        }

        public Task<IEnumerable<ClientDto>> GetAllClientsWithPaging(int pageNumber, int pageSize)
        {
            return Get<IEnumerable<ClientDto>>($"api/Client/paging?pageNumber={pageNumber}&pageSize={pageSize}");
        }
    }



}
