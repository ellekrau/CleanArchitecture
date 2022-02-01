using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Products.Commands;

namespace CleanArchitecture.Application.Mappings
{
    public class CommandToDTOMappingProfile : Profile
    {
        public CommandToDTOMappingProfile()
        {
            CreateMap<ProductCreateCommand, ProductDTO>();
            CreateMap<ProductUpdateCommand, ProductDTO>();
        }
    }
}
