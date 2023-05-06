using AutoMapper;
using HackTest.Application.DTOs;
using HackTest.Domain.Entities;

namespace HackTest.Application.Mapping;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
