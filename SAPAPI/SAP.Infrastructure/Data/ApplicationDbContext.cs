using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;

namespace SAP.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<InventarioVendedor> InventarioVendedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Asistencia
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Estado).IsRequired();
                entity.HasOne(e => e.Empleado)
                    .WithMany()
                    .HasForeignKey(e => e.EmpleadoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
} 