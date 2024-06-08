using BLL.DTO.Product;

namespace BLL.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsWithPaging(int pageNumber, int pageSize);
        Task<List<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetProductById(string id);
        Task<ProductDto> CreateProduct(ProductCreateDto model);
        Task<bool?> DeleteProduct(string id);
        Task<ProductDto?> UpdateProduct(string id, productUpdateDto model);

    }
}
