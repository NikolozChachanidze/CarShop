using AutoMapper;
using CarShop.Dtos;
using CarShop.Entityes;

namespace CarShop.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategoryResponseDto>();
        }
    }
}
