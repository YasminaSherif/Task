using AutoMapper;
using BLL.DTO.Client;
using BLL.Services.Contracts;
using DAL.Models;
using DAL.Repositories.Contracts;



namespace BLL.Services
{
    public class ClientServices : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _repository;

        public ClientServices(IMapper mapper, IClientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ClientDto> CreateClient(ClientCreateDto model)
        {
            if (await _repository.CodeExists(model.Code))
            {
                throw new ArgumentException("A client with this code already exists.");
            }
            var client = new Client();
            if (Enum.TryParse<ClientState>(model.State, false, out var state))
            {
                client.State = state;
            }
            else
            {
                throw new ArgumentException("Invalid state value");
            }
            if (Enum.TryParse<ClientClass>(model.Class, false, out var clientClass))
            {
                client.Class = clientClass;
            }
            else
            {
                throw new ArgumentException("Invalid class value");
            }

            client.Id = Guid.NewGuid().ToString();
            client.Name = model.Name;
            client.Code = model.Code;

            var createdClient = await _repository.Add(client);

            return _mapper.Map<ClientDto>(createdClient);
        }



        public async Task<bool> DeleteClient(string id)
        {
            var client = await _repository.GetClientDetailsById(id);
            if (client == null)
            {
                throw new Exception("client Not found");
            }
            if (client.ClientProducts.Any())
            {
                throw new Exception(
                    "there are Products connected to this client"
                    );
            }
            return await _repository.Delete(client);
        }

        public async Task<List<ClientDto>> GetAllClients()
        {
            var listOfClients = await _repository.GetAll();
            if (listOfClients == null || !listOfClients.Any())
            {
                return new List<ClientDto>();
            }
            return listOfClients.Select(p => _mapper.Map<ClientDto>(p)).ToList();
        }

        public async Task<List<ClientDto>> GetAllClientsWithPaging(int pageNumber, int pageSize)
        {
            var listOfClients = await GetAllClients();

            if (listOfClients == null || !listOfClients.Any())
            {
                return new List<ClientDto>();
            }

            return listOfClients.Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .OrderBy(c => c.Code)
                 .ToList();
        }

        public async Task<ClientWithDtailesDto?> GetClientDetailsById(String id)
        {
            var client = await _repository.GetClientDetailsById(id);
            return client is not null ? _mapper.Map<ClientWithDtailesDto>(client) : null;
        }

        public async Task<ClientDto?> UpdateClient(string id, ClientDto model)
        {
            var client = await _repository.GetById(id);
            if (client is null)
            {
                return null;
            }
            if (Enum.TryParse<ClientState>(model.State, false, out var state))
            {
                client.State = state;
            }
            else
            {
                throw new ArgumentException("Invalid state value");
            }
            client.Name = model.Name;

            if (Enum.TryParse<ClientClass>(model.State, false, out var clientClass))
            {
                client.Class = clientClass;
            }
            else
            {
                throw new ArgumentException("Invalid class value");
            }

            var updatedClient = await _repository.Update(client);
            return _mapper.Map<ClientDto>(updatedClient);


        }
    }
}
