using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace MVCWEB.Infrastructe.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
        CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserDtoForInsertion, User>().ReverseMap();
        CreateMap<UserDtoForUpdate, User>().ReverseMap();
    }
}