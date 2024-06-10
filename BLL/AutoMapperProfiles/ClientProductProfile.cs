using AutoMapper;
using DTO.Client;
using DTO.ClientProduct;
using DAL.Models;

namespace BLL.AutoMapperProfiles
{
    public class ClientProductProfile : Profile
    {
        public ClientProductProfile()
        {
            CreateMap<ClientProduct, ClientProductDto>().ReverseMap();
            CreateMap<ClientProductCreateDto, ClientProduct>();
            CreateMap<ClientWithDtailesDto, Client>().ReverseMap();
        }
    }
}
