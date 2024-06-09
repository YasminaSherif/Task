using AutoMapper;
using DTO.ClientProduct;
using BLL.Services.Contracts;
using DAL.Models;
using DAL.Repositories.Contracts;

namespace BLL.Services
{
    public class ClientProductService : IClinetProductService
    {
        private readonly IRepository<ClientProduct> _clientProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientProductService(IRepository<ClientProduct> ClientProductRepository, IProductRepository productRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _clientProductRepository = ClientProductRepository;
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientProductDto> CreateClientProduct(ClientProductCreateDto model)
        {
            var product = await _productRepository.GetById(model.ProductId);
            if (product is null)
                throw new Exception("Product is not found");
            if (product.IsActive == false)
                throw new Exception("Product is not active");
            var client = await _clientRepository.GetById(model.ClientId);
            if (client is null)
                throw new Exception("Client not found");

            var clientProduct = _mapper.Map<ClientProduct>(model);
            clientProduct.Id = Guid.NewGuid().ToString();
            clientProduct.Product = product;
            clientProduct.Client = client;
            var createdClientProduct = await _clientProductRepository.Add(clientProduct);
            return _mapper.Map<ClientProductDto>(createdClientProduct);
        }

        public async Task<bool> DeleteClientProduct(string id)
        {
            var clientProduct = await _clientProductRepository.GetById(id);
            if (clientProduct == null)
            {
                throw new Exception("ClientProduct doesn't exists");
            }

            return await _clientProductRepository.Delete(clientProduct); ;
        }

        public async Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdate model)
        {
            var productClient = await _clientProductRepository.GetById(id);
            if (productClient is null)
            {
                return null;
            }
            productClient.License = model.License;
            productClient.EndDate = model.EndDate;
            productClient.StartDate = model.StartDate;

            var updatedClientProduct = await _clientProductRepository.Update(productClient);
            return _mapper.Map<ClientProductDto>(updatedClientProduct);


        }

        public async Task<ClientProductDto?> GetClientProductById(String id)
        {
            var clientProduct = await _clientProductRepository.GetById(id);
            return clientProduct is not null ? _mapper.Map<ClientProductDto>(clientProduct) : null;
        }
    }


}
