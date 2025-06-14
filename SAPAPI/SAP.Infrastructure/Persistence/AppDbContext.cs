using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;

namespace SAP.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<ProductoAtributo> ProductoAtributos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<InventarioVendedor> InventarioVendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<PermisoSalida> PermisosSalida { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Activo).IsRequired();
                entity.Property(e => e.FechaCreacion).IsRequired();
                entity.HasMany(e => e.UsuarioRoles)
                    .WithOne(ur => ur.Usuario)
                    .HasForeignKey(ur => ur.UsuarioId);
            });

            // Configuración de Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolId);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).HasMaxLength(200);
                entity.HasMany(e => e.UsuarioRoles)
                    .WithOne(ur => ur.Rol)
                    .HasForeignKey(ur => ur.RolId);
            });

            // Configuración de UsuarioRol
            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.RolId });
                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.UsuarioRoles)
                    .HasForeignKey(e => e.UsuarioId);
                entity.HasOne(e => e.Rol)
                    .WithMany(r => r.UsuarioRoles)
                    .HasForeignKey(e => e.RolId);
            });

            // Configuración de Empleado
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.EmpleadoId);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FechaContratacion).IsRequired();
                entity.Property(e => e.Salario).HasPrecision(10, 2);
                entity.Property(e => e.Cargo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Activo).IsRequired();
                entity.HasOne(e => e.Usuario)
                    .WithOne(u => u.Empleado)
                    .HasForeignKey<Empleado>(e => e.UsuarioId);
                entity.HasOne(e => e.Sucursal)
                    .WithMany(s => s.Empleados)
                    .HasForeignKey(e => e.SucursalId);
                entity.HasMany(e => e.Asistencias)
                    .WithOne(a => a.Empleado)
                    .HasForeignKey(a => a.EmpleadoId);
                entity.HasMany(e => e.Incidencias)
                    .WithOne(i => i.Empleado)
                    .HasForeignKey(i => i.EmpleadoId);
                entity.HasMany(e => e.PermisosSalida)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey(p => p.EmpleadoId);
                entity.HasMany(e => e.InventarioVendedores)
                    .WithOne(iv => iv.Empleado)
                    .HasForeignKey(iv => iv.EmpleadoId);
                entity.HasMany(e => e.Ventas)
                    .WithOne(v => v.Empleado)
                    .HasForeignKey(v => v.EmpleadoId);
            });

            // Configuración de Sucursal
            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.SucursalId);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Activa).IsRequired();
                entity.Property(e => e.FechaApertura).IsRequired();
                entity.HasMany(e => e.Empleados)
                    .WithOne(em => em.Sucursal)
                    .HasForeignKey(em => em.SucursalId);
                entity.HasMany(e => e.Inventarios)
                    .WithOne(i => i.Sucursal)
                    .HasForeignKey(i => i.SucursalId);
                entity.HasMany(e => e.Ventas)
                    .WithOne(v => v.Sucursal)
                    .HasForeignKey(v => v.SucursalId);
            });

            // Configuración de Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Activa).IsRequired();
                entity.Property(e => e.FechaCreacion).IsRequired();
                entity.HasMany(e => e.Productos)
                    .WithOne(p => p.Categoria)
                    .HasForeignKey(p => p.CategoriaId);
            });

            // Configuración de Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProductoId);
                entity.Property(e => e.Codigo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.PrecioVenta).HasPrecision(10, 2);
                entity.Property(e => e.PrecioCompra).HasPrecision(10, 2);
                entity.Property(e => e.Activo).IsRequired();
                entity.HasOne(e => e.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(e => e.CategoriaId);
            });

            // Configuración de Atributo
            modelBuilder.Entity<Atributo>(entity =>
            {
                entity.HasKey(e => e.AtributoId);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FechaCreacion).IsRequired();
            });

            // Configuración de ProductoAtributo
            modelBuilder.Entity<ProductoAtributo>(entity =>
            {
                entity.HasKey(e => new { e.ProductoId, e.AtributoId });
                entity.HasOne(e => e.Producto)
                    .WithMany(p => p.ProductoAtributos)
                    .HasForeignKey(e => e.ProductoId);
                entity.HasOne(e => e.Atributo)
                    .WithMany(a => a.ProductoAtributos)
                    .HasForeignKey(e => e.AtributoId);
            });

            // Configuración de Inventario
            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.InventarioId);
                entity.Property(e => e.Cantidad).IsRequired();
                entity.HasOne(e => e.Producto)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(e => e.ProductoId);
                entity.HasOne(e => e.Sucursal)
                    .WithMany(s => s.Inventarios)
                    .HasForeignKey(e => e.SucursalId);
            });

            // Configuración de InventarioVendedor
            modelBuilder.Entity<InventarioVendedor>(entity =>
            {
                entity.HasKey(e => e.InventarioVendedorId);
                entity.Property(e => e.Cantidad).IsRequired();
                entity.HasOne(e => e.Producto)
                    .WithMany(p => p.InventarioVendedores)
                    .HasForeignKey(e => e.ProductoId);
                entity.HasOne(e => e.Empleado)
                    .WithMany(em => em.InventarioVendedores)
                    .HasForeignKey(e => e.EmpleadoId);
            });

            // Configuración de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Activo).IsRequired();
                entity.Property(e => e.FechaRegistro).IsRequired();
                entity.HasMany(e => e.Ventas)
                    .WithOne(v => v.Cliente)
                    .HasForeignKey(v => v.ClienteId);
            });

            // Configuración de Venta
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.VentaId);
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Total).HasPrecision(10, 2);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Ventas)
                    .HasForeignKey(e => e.ClienteId);
                entity.HasOne(e => e.Empleado)
                    .WithMany(em => em.Ventas)
                    .HasForeignKey(e => e.EmpleadoId);
                entity.HasOne(e => e.Sucursal)
                    .WithMany(s => s.Ventas)
                    .HasForeignKey(e => e.SucursalId);
                entity.HasMany(e => e.DetalleVentas)
                    .WithOne(d => d.Venta)
                    .HasForeignKey(d => d.VentaId);
            });

            // Configuración de DetalleVenta
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.DetalleVentaId);
                entity.Property(e => e.Cantidad).IsRequired();
                entity.Property(e => e.PrecioUnitario).HasPrecision(10, 2);
                entity.Property(e => e.Subtotal).HasPrecision(10, 2);
                entity.HasOne(e => e.Venta)
                    .WithMany(v => v.DetalleVentas)
                    .HasForeignKey(e => e.VentaId);
                entity.HasOne(e => e.Producto)
                    .WithMany(p => p.DetalleVentas)
                    .HasForeignKey(e => e.ProductoId);
            });

            // Configuración de Asistencia
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.AsistenciaId);
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.HoraEntrada).IsRequired();
                entity.Property(e => e.HoraSalida);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.HasOne(e => e.Empleado)
                    .WithMany(em => em.Asistencias)
                    .HasForeignKey(e => e.EmpleadoId);
            });

            // Configuración de PermisoSalida
            modelBuilder.Entity<PermisoSalida>(entity =>
            {
                entity.HasKey(e => e.PermisoSalidaId);
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.HoraInicio).IsRequired();
                entity.Property(e => e.HoraFin).IsRequired();
                entity.Property(e => e.Motivo).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.HasOne(e => e.Empleado)
                    .WithMany(em => em.PermisosSalida)
                    .HasForeignKey(e => e.EmpleadoId);
            });

            // Configuración de Incidencia
            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.HasKey(e => e.IncidenciaId);
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.HasOne(e => e.Empleado)
                    .WithMany(em => em.Incidencias)
                    .HasForeignKey(e => e.EmpleadoId);
            });

            // Configuración de Bitacora
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.BitacoraId);
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Accion).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);
                entity.Property(e => e.UsuarioId).IsRequired();
            });
        }
    }
}
