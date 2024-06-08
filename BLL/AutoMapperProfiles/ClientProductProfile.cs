using AutoMapper;
using BLL.DTO.Client;
using BLL.DTO.ClientProduct;
using DAL.Models;

namespace BLL.AutoMapperProfiles
{
    public class ClientProductProfile:Profile
    {
        public ClientProductProfile()
        {
            CreateMap<ClientProduct,ClientProductDto>().ReverseMap();
            CreateMap<ClientProductCreateDto, ClientProduct>();
            CreateMap<ClientWithDtailesDto,Client>().ReverseMap();
        }
    }
}
