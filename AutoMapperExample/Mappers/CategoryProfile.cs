using AutoMapper;
using AutoMapperExample.DTOs;
using AutoMapperExample.Entities;

namespace AutoMapperExample.Mappers
{
    public class CategoryProfile : Profile
    {
        // Cada Entidad necesita su propia clase que herede de perfil para crear el mapper
        public CategoryProfile() 
        {
            // Create map crea el map
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Desc, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
            // ForMember mapea propiedades que tienen nombre diferente 
            // Si en tu modelo de datos y tu modelo de vista las propiedades son las mismas entonces no te preocupes por usar ForMemeber
            // ReverseMap quiere decir que puedes mapear Category a CategoryViewModel como CategoryViewModel a Category
        }
    }
}
