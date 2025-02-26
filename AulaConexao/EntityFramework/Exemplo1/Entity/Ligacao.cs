using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class Ligacao : DbContext // Herda a classe principal do entity framework
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=dataconnect;Username=postgres;Password=30427693");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
        }
    }
}