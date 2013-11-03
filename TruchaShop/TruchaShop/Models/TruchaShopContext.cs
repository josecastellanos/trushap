using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TruchaShop.Models
{
    public class TruchaShopContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProductoCompania> ProductosCompania { get; set; }
        public DbSet<Existencia> Existencias { get; set; }

        public TruchaShopContext()
            : base("name=TruchaShopConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TruchaShopContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Usuario
            
            modelBuilder.Entity<Usuario>().ToTable("Usuario", "dbo");
            modelBuilder.Entity<Usuario>().HasKey(m => m.UsuarioId);
            modelBuilder.Entity<Usuario>()
                .Property(m => m.UsuarioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            #endregion

            #region Producto_Compania

            modelBuilder.Entity<ProductoCompania>().ToTable("Producto_Compania", "dbo");
            modelBuilder.Entity<ProductoCompania>().HasKey(m => new { m.ProductoId, m.ProductoCompaniaId });
            modelBuilder.Entity<ProductoCompania>()
                .Property(m => m.ProductoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            #endregion
            
            #region Existencia
            
            modelBuilder.Entity<Existencia>().ToTable("Existencia", "dbo");
            modelBuilder.Entity<Existencia>().HasKey(m => new { m.ExistenciaId, m.ExistenciaProductoId });
            modelBuilder.Entity<Existencia>()
                .Property(m => m.ExistenciaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Existencia>()
                .HasRequired(a => a.ProductoCompania)
                .WithMany(m => m.Existencias)
                .HasForeignKey(a => new { a.ExistenciaProductoId, a.ExistenciaProductoCompaniaId });
            modelBuilder.Entity<Existencia>()
                .HasRequired(a => a.ProductoCompania)
                .WithMany(m => m.Existencias)
                .HasForeignKey(a => new { a.ExistenciaProductoId, a.ExistenciaProductoCompaniaId })
                .WillCascadeOnDelete(true);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}