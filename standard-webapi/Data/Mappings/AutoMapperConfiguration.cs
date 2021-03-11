using AutoMapper;
using standard_webapi.Data.DTOs;
using standard_webapi.Models;

namespace standard_webapi.Data.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}