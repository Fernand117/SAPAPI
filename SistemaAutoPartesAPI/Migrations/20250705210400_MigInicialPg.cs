using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaAutoPartesAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigInicialPg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasProducto",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    CategoriaPadreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__F353C1E55E088816", x => x.CategoriaId);
                    table.ForeignKey(
                        name: "FK_CategoriasProducto_Padre",
                        column: x => x.CategoriaPadreId,
                        principalTable: "CategoriasProducto",
                        principalColumn: "CategoriaId");
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Modulo = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__96E0C723A940671A", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__F92302F1D3BB479E", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    SucursalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Ciudad = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sucursal__6CB482E1265D3819", x => x.SucursalId);
                });

            migrationBuilder.CreateTable(
                name: "AtributosProducto",
                columns: table => new
                {
                    AtributoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    TipoDato = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Atributo__8AB1659A36881035", x => x.AtributoId);
                    table.ForeignKey(
                        name: "FK_AtributosProducto_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasProducto",
                        principalColumn: "CategoriaId");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Marca = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__A430AEA33A48C24C", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasProducto",
                        principalColumn: "CategoriaId");
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "integer", nullable: false),
                    PermisoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RolPermi__D04D0E8320092D2B", x => new { x.RolId, x.PermisoId });
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permiso",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "PermisoId");
                    table.ForeignKey(
                        name: "FK_RolPermiso_Rol",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    RFC = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    SucursalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__71ABD08705C1CFA9", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    Genero = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    CURP = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    RFC = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    NSS = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    FotoUrl = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__958BE9104CFAAEC0", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMoviles",
                columns: table => new
                {
                    UnidadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Marca = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Modelo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Placa = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Activa = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Unidades__C6F324D653AB5928", x => x.UnidadId);
                    table.ForeignKey(
                        name: "FK_UnidadesMoviles_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__FB8A24D759835E82", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_Inventario_Producto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_Inventario_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                });

            migrationBuilder.CreateTable(
                name: "MovimientosInventario",
                columns: table => new
                {
                    MovimientoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "timestamp", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    ReferenciaId = table.Column<int>(type: "integer", nullable: true),
                    Origen = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true),
                    Notas = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movimien__BF923C2CFA483A44", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_MovInv_Producto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_MovInv_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                });

            migrationBuilder.CreateTable(
                name: "ProductoAtributoValor",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    AtributoId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__1C9BB8FA79036D6B", x => new { x.ProductoId, x.AtributoId });
                    table.ForeignKey(
                        name: "FK_ProductoAtributoValor_Atributo",
                        column: x => x.AtributoId,
                        principalTable: "AtributosProducto",
                        principalColumn: "AtributoId");
                    table.ForeignKey(
                        name: "FK_ProductoAtributoValor_Producto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    AsistenciaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraEntrada = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    HoraSalida = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Observaciones = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asistenc__72710FA5C055786A", x => x.AsistenciaId);
                    table.ForeignKey(
                        name: "FK_Asistencias_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    IncidenciaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Justificada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Incidenc__E41133E62CD1F187", x => x.IncidenciaId);
                    table.ForeignKey(
                        name: "FK_Incidencias_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Nominas",
                columns: table => new
                {
                    NominaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    SueldoBase = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Bonos = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Deducciones = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TotalPagar = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nominas__33A37612A9B507AC", x => x.NominaId);
                    table.ForeignKey(
                        name: "FK_Nominas_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "PermisosSalida",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraSalida = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    HoraRegreso = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Motivo = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    Autorizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__96E0C723DBBED833", x => x.PermisoId);
                    table.ForeignKey(
                        name: "FK_PermisosSalida_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    RolId = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__2B3DE7B8177A4680", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    BitacoraId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaHora = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    Accion = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Tabla = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    RegistroId = table.Column<int>(type: "integer", nullable: true),
                    Detalles = table.Column<string>(type: "text", nullable: true),
                    IP = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bitacora__7ACF9B389483575F", x => x.BitacoraId);
                    table.ForeignKey(
                        name: "FK_Bitacora_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                    table.ForeignKey(
                        name: "FK_Bitacora_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "InventarioVendedor",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__E11259D0566D7644", x => new { x.UsuarioId, x.ProductoId, x.SucursalId });
                    table.ForeignKey(
                        name: "FK_InventarioVendedor_Producto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_InventarioVendedor_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                    table.ForeignKey(
                        name: "FK_InventarioVendedor_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsuarioR__24AFD797AA3D2388", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId");
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioUnidad",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    UnidadId = table.Column<int>(type: "integer", nullable: false),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    FechaAsignacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsuarioU__B73E6177AAFFE446", x => new { x.UsuarioId, x.UnidadId, x.SucursalId });
                    table.ForeignKey(
                        name: "FK_UsuarioUnidad_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                    table.ForeignKey(
                        name: "FK_UsuarioUnidad_Unidad",
                        column: x => x.UnidadId,
                        principalTable: "UnidadesMoviles",
                        principalColumn: "UnidadId");
                    table.ForeignKey(
                        name: "FK_UsuarioUnidad_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    SucursalId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FormaPago = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Notas = table.Column<string>(type: "text", nullable: true),
                    FirmaUrl = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    UbicacionGeo = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ventas__5B4150ACAEEDFE50", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Ventas_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Ventas_Sucursal",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "SucursalId");
                    table.ForeignKey(
                        name: "FK_Ventas_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VentaId = table.Column<int>(type: "integer", nullable: false),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleV__6E19D6DA4AAA2BD0", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Producto",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Venta",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EmpleadoId",
                table: "Asistencias",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtributosProducto_CategoriaId",
                table: "AtributosProducto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_SucursalId",
                table: "Bitacora",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_UsuarioId",
                table: "Bitacora",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProducto_CategoriaPadreId",
                table: "CategoriasProducto",
                column: "CategoriaPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SucursalId",
                table: "Clientes",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_ProductoId",
                table: "DetalleVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_VentaId",
                table: "DetalleVenta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SucursalId",
                table: "Empleados",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "UQ__Empleado__A9D105343D1D831E",
                table: "Empleados",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_EmpleadoId",
                table: "Incidencias",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_ProductoId",
                table: "Inventario",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_SucursalId",
                table: "Inventario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioVendedor_ProductoId",
                table: "InventarioVendedor",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioVendedor_SucursalId",
                table: "InventarioVendedor",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventario_ProductoId",
                table: "MovimientosInventario",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventario_SucursalId",
                table: "MovimientosInventario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_EmpleadoId",
                table: "Nominas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosSalida_EmpleadoId",
                table: "PermisosSalida",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAtributoValor_AtributoId",
                table: "ProductoAtributoValor",
                column: "AtributoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoId",
                table: "RolPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesMoviles_SucursalId",
                table: "UnidadesMoviles",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_RolId",
                table: "UsuarioRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpleadoId",
                table: "Usuarios",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__536C85E498F79612",
                table: "Usuarios",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidad_SucursalId",
                table: "UsuarioUnidad",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidad_UnidadId",
                table: "UsuarioUnidad",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_SucursalId",
                table: "Ventas",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "InventarioVendedor");

            migrationBuilder.DropTable(
                name: "MovimientosInventario");

            migrationBuilder.DropTable(
                name: "Nominas");

            migrationBuilder.DropTable(
                name: "PermisosSalida");

            migrationBuilder.DropTable(
                name: "ProductoAtributoValor");

            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "UsuarioUnidad");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "AtributosProducto");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UnidadesMoviles");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CategoriasProducto");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
