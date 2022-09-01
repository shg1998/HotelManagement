using AutoMapper;
using HotelManagement.Data;
using HotelManagement.Models;

namespace HotelManagement.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<ApiUser, UserDto>().ReverseMap();
            CreateMap<ApiUser, LoginDto>().ReverseMap();
        }
    }
}
