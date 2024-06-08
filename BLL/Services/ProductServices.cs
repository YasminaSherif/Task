using AutoMapper;
using BLL.DTO.Client;
using BLL.DTO.Product;
using BLL.Services.Contracts;
using DAL.Models;
using DAL.Repositories.Contracts;

namespace BLL.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProduct(ProductCreateDto model)
        {
            var product = _mapper.Map<Product>(model);
            product.Id = Guid.NewGuid().ToString();
            var createdProduct = await _repository.Add(product);
            return _mapper.Map<ProductDto>(createdProduct);
        }


        public async Task<bool?> DeleteProduct(string id)
        {
            var product = await _repository.GetProductDetailsById(id);
            if (product == null)
            {
                return false;
            }
            if (product.ClientProducts.Any())
            {
                throw new Exception(
                    "there are clients connected to this product"
                    );
            }

            return await _repository.Delete(product);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var listOfProducts = await _repository.GetAll();
            if (listOfProducts == null || !listOfProducts.Any())
            {
                return new List<ProductDto>();
            }
            return listOfProducts.Select(p => _mapper.Map<ProductDto>(p)).ToList();
        }

        public async Task<List<ProductDto>> GetAllProductsWithPaging(int pageNumber, int pageSize)
        {
            var listOfProducts = await GetAllProducts();
            if (listOfProducts == null || !listOfProducts.Any())
            {
                return new List<ProductDto>();
            }
            return listOfProducts.Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .OrderBy(p => p.Name)
                 .ToList();

        }

        public async Task<ProductDto?> GetProductById(string id)
        {
            var product = await _repository.GetById(id);

            if (product is not null)
                return _mapper.Map<ProductDto>(product);
            else
                return null;

        }

        public async Task<ProductDto?> UpdateProduct(string id, productUpdateDto model)
        {
            var product = await _repository.GetById(id);
            if (product is null)
            {
                return null;
            }
            product.Name = model.Name;
            product.Description = model.Description;
            product.IsActive = model.IsActive;

            var updatedProduct = await _repository.Update(product);
            return _mapper.Map<ProductDto>(updatedProduct);





        }


    }
}
