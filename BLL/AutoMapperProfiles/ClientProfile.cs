using AutoMapper;
using BLL.DTO.Client;
using DAL.Models;

namespace BLL.AutoMapperProfiles
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientCreateDto, Client>().ReverseMap();
        }
    }
}
