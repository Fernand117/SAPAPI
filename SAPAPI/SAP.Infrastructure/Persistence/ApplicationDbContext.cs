using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;

namespace SAP.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<ProductoAtributo> ProductoAtributos { get; set; }
        public DbSet<InventarioVendedor> InventarioVendedores { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Inventario
            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Producto)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(e => e.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Sucursal)
                    .WithMany(s => s.Inventarios)
                    .HasForeignKey(e => e.SucursalId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de ProductoAtributo
            modelBuilder.Entity<ProductoAtributo>(entity =>
            {
                entity.HasKey(e => e.ProductoAtributoId);
                entity.HasOne(e => e.Producto)
                    .WithMany(p => p.ProductoAtributos)
                    .HasForeignKey(e => e.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Atributo)
                    .WithMany(a => a.ProductoAtributos)
                    .HasForeignKey(e => e.AtributoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de InventarioVendedor
            modelBuilder.Entity<InventarioVendedor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Producto)
                    .WithMany()
                    .HasForeignKey(e => e.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Vendedor)
                    .WithMany()
                    .HasForeignKey(e => e.VendedorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Asistencia
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Empleado)
                    .WithMany(em => em.Asistencias)
                    .HasForeignKey(e => e.EmpleadoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
} 