using AutoMapper;
using CarShop.Dtos;
using CarShop.Entityes;

namespace CarShop.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
            CreateMap<Car, CarResponseDto>();
        }
    }
}
