using AutoMapper;
using SAP.Application.DTOs;
using SAP.Domain.Entities;

namespace SAP.Application.Mappings
{
    public class InventarioProfile : Profile
    {
        public InventarioProfile()
        {
            CreateMap<Inventario, InventarioDto>()
                .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto.Nombre))
                .ForMember(dest => dest.CodigoProducto, opt => opt.MapFrom(src => src.Producto.Codigo))
                .ForMember(dest => dest.NombreSucursal, opt => opt.MapFrom(src => src.Sucursal.Nombre))
                .ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => src.Producto.PrecioVenta));

            CreateMap<Inventario, InventarioDetalleDto>()
                .IncludeBase<Inventario, InventarioDto>();

            CreateMap<CreateInventarioDto, Inventario>();
            CreateMap<UpdateInventarioDto, Inventario>();
        }
    }
} 