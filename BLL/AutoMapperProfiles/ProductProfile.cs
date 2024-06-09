using AutoMapper;
using DTO.Product;
using DAL.Models;

namespace BLL.AutoMapperProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
