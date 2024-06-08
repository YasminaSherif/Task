using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Client> Clients {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }

        public ApplicationContext() :base()
        {
            
        }

        public ApplicationContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ELNCRIE\\SQLEXPRESS;Database=ProductClientDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(n => n.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Client>()
                .Property(c => c.Code)
                .HasMaxLength(9);

            modelBuilder.Entity<Client>()
            .HasIndex(c => c.Code)
            .IsUnique();

            modelBuilder.Entity<Product>()
               .Property(n => n.Name)
               .HasMaxLength(50);

            modelBuilder.Entity<Product>()
               .Property(d => d.Description)
               .HasMaxLength(155);

            modelBuilder.Entity<ClientProduct>()
             .Property(l => l.License)
             .HasMaxLength(255);



            modelBuilder.Entity<ClientProduct>()
                .HasOne(p => p.Product)
                .WithMany(cp => cp.ClientProducts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientProduct>()
              .HasOne(c=>c.Client)
              .WithMany(cp => cp.ClientProducts)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
