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
        public DbSet<RolPermiso> RolPermisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.HasNoKey();
                
                entity.HasOne(rp => rp.Rol)
                      .WithMany(r => r.RolPermisos)
                      .HasForeignKey(rp => rp.RolId);

                entity.HasOne(rp => rp.Permiso)
                      .WithMany(p => p.RolPermisos)
                      .HasForeignKey(rp => rp.PermisoId);
            });
        }
    }
}