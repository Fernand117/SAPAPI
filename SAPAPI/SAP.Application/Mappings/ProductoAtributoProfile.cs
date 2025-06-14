using AutoMapper;
using SAP.Application.DTOs;
using SAP.Domain.Entities;

namespace SAP.Application.Mappings
{
    public class ProductoAtributoProfile : Profile
    {
        public ProductoAtributoProfile()
        {
            CreateMap<ProductoAtributo, ProductoAtributoValorDto>()
                .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto.Nombre))
                .ForMember(dest => dest.NombreAtributo, opt => opt.MapFrom(src => src.Atributo.Nombre));

            CreateMap<ProductoAtributo, ProductoAtributoValorDetalleDto>()
                .IncludeBase<ProductoAtributo, ProductoAtributoValorDto>();

            CreateMap<CreateProductoAtributoValorDto, ProductoAtributo>();
            CreateMap<UpdateProductoAtributoValorDto, ProductoAtributo>();
        }
    }
} 