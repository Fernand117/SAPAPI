using AutoMapper;
using SAP.Application.DTOs;
using SAP.Domain.Entities;

namespace SAP.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Usuario mappings
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();

            // Mapeos para Rol
            CreateMap<Rol, RolDto>();
            CreateMap<CreateRolDto, Rol>();
            CreateMap<UpdateRolDto, Rol>();

            // Mapeos para Permiso
            CreateMap<Permiso, PermisoDto>();
            CreateMap<CreatePermisoDto, Permiso>();
            CreateMap<UpdatePermisoDto, Permiso>();

            // Mapeos para Atributo
            CreateMap<Atributo, AtributoDto>();
            CreateMap<CreateAtributoDto, Atributo>();
            CreateMap<UpdateAtributoDto, Atributo>();

            // Mapeos para Bitacora
            CreateMap<Bitacora, BitacoraDto>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario.Username));
            CreateMap<CreateBitacoraDto, Bitacora>();
            CreateMap<UpdateBitacoraDto, Bitacora>();

            // Mapeos para PermisoSalida
            CreateMap<PermisoSalida, PermisoSalidaDto>();
            CreateMap<CreatePermisoSalidaDto, PermisoSalida>();
            CreateMap<UpdatePermisoSalidaDto, PermisoSalida>();

            // Mapeos para Incidencia
            CreateMap<Incidencia, IncidenciaDto>();
            CreateMap<CreateIncidenciaDto, Incidencia>();
            CreateMap<UpdateIncidenciaDto, Incidencia>();

            // Mapeos para Nomina
            CreateMap<Nomina, NominaDto>();
            CreateMap<CreateNominaDto, Nomina>();
            CreateMap<UpdateNominaDto, Nomina>();

            // Mapeos para UnidadMovil
            CreateMap<UnidadMovil, UnidadMovilDto>();
            CreateMap<CreateUnidadMovilDto, UnidadMovil>();
            CreateMap<UpdateUnidadMovilDto, UnidadMovil>();

            // Mapeos para UsuarioUnidad
            CreateMap<UsuarioUnidad, UsuarioUnidadDto>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario.Username))
                .ForMember(dest => dest.PlacaUnidad, opt => opt.MapFrom(src => src.UnidadMovil.Placa));
            CreateMap<CreateUsuarioUnidadDto, UsuarioUnidad>();
            CreateMap<UpdateUsuarioUnidadDto, UsuarioUnidad>();

            // Mapeos para ProductoAtributoValor
            CreateMap<ProductoAtributoValor, ProductoAtributoValorDto>()
                .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto.Nombre))
                .ForMember(dest => dest.NombreAtributo, opt => opt.MapFrom(src => src.Atributo.Nombre));
            CreateMap<CreateProductoAtributoValorDto, ProductoAtributoValor>();
            CreateMap<UpdateProductoAtributoValorDto, ProductoAtributoValor>();

            // Mapeos para CategoriaProducto
            CreateMap<CategoriaProducto, CategoriaProductoDto>();
            CreateMap<CreateCategoriaProductoDto, CategoriaProducto>();
            CreateMap<UpdateCategoriaProductoDto, CategoriaProducto>();

            // Mapeos para RolPermiso
            CreateMap<RolPermiso, RolPermisoDto>()
                .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.Rol.Nombre))
                .ForMember(dest => dest.NombrePermiso, opt => opt.MapFrom(src => src.Permiso.Nombre));
            CreateMap<CreateRolPermisoDto, RolPermiso>();
            CreateMap<UpdateRolPermisoDto, RolPermiso>();

            // Mapeos para UsuarioRol
            CreateMap<UsuarioRol, UsuarioRolDto>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario.Username))
                .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.Rol.Nombre));
            CreateMap<CreateUsuarioRolDto, UsuarioRol>();
            CreateMap<UpdateUsuarioRolDto, UsuarioRol>();
        }
    }
} 