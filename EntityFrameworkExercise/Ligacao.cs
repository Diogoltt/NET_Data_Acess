using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExercise
{
    public class Ligacao : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Software> Softwares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=entityframeworkexercise;Username=postgres;Password=30427693");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração das tabelas
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Maquina>().ToTable("maquina");
            modelBuilder.Entity<Software>().ToTable("software");

            // Configuração dos relacionamentos
            modelBuilder.Entity<Maquina>()
                .HasOne(m => m.Usuario) // Uma máquina pertence a um usuário
                .WithMany(u => u.Maquinas) // Um usuário pode ter várias máquinas
                .HasForeignKey(m => m.UsuarioId) // Chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Software>()
                .HasOne(s => s.Maquina) // Um software pertence a uma máquina
                .WithMany(m => m.Softwares) // Uma máquina pode ter vários softwares
                .HasForeignKey(s => s.MaquinaId) // Chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}