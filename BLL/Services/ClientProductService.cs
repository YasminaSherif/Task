using AutoMapper;
using DTO.ClientProduct;
using BLL.Services.Contracts;
using DAL.Models;
using DAL.Repositories.Contracts;
using DAL.Repositories;
using DTO.Client;

namespace BLL.Services
{
    public class ClientProductService : IClinetProductService
    {
        private readonly IClientProductRepository _clientProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientProductService(IClientProductRepository ClientProductRepository, IProductRepository productRepository, IClientRepository clientRepository, IMapper mapper)
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

        public async Task<ClientProductDto?> UpdateClientProduct(string id, ClientProductUpdateDto model)
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


        public async Task<List<ClientProductDto>?> GetAllClientProducts()
        {
            var listOfClientProducts = await _clientProductRepository.GetAll();
            if (listOfClientProducts == null || !listOfClientProducts.Any())
            {
                return new List<ClientProductDto>();
            }
            return listOfClientProducts.Select(p => _mapper.Map<ClientProductDto>(p)).ToList();
        }

        public async Task<ClientProductDetailesDto?> GetClientProductDetailsById(string id)
        {
            var clientProduct = await _clientProductRepository.GetClientProductDetailsById(id);
            return clientProduct is not null ? new ClientProductDetailesDto
            {
                ClientId = clientProduct.Id,
                ClientName = clientProduct.Client.Name,
                EndDate = clientProduct.EndDate,
                Id = id,
                License = clientProduct.License,
                ProductId = clientProduct.ProductId,
                ProductName = clientProduct.Product.Name,
                StartDate = clientProduct.StartDate,
            } : null;
        }
    }
}



