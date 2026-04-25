using AutoMapper;
using NorthwindCatalog.Services.DTO;
using NorthwindCatalog.Services.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => "/images/" + src.CategoryName + ".jpg"));

        CreateMap<Product, ProductDto>();
    }
}