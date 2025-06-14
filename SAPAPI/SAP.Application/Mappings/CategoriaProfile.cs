using AutoMapper;
using SAP.Application.DTOs;
using SAP.Domain.Entities;

namespace SAP.Application.Mappings
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>()
                .ForMember(dest => dest.NombreCategoriaPadre, opt => opt.MapFrom(src => src.CategoriaPadre != null ? src.CategoriaPadre.Nombre : null))
                .ForMember(dest => dest.TotalProductos, opt => opt.MapFrom(src => src.Productos != null ? src.Productos.Count : 0));

            CreateMap<Categoria, CategoriaDetalleDto>()
                .IncludeBase<Categoria, CategoriaDto>();

            CreateMap<CreateCategoriaDto, Categoria>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => System.DateTime.UtcNow))
                .ForMember(dest => dest.Activa, opt => opt.MapFrom(src => true));

            CreateMap<UpdateCategoriaDto, Categoria>();
        }
    }
} 