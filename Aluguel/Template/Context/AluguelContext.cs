using Microsoft.EntityFrameworkCore;
using Template.Models;

namespace Template.Context
{
    public class AluguelContext : DbContext
    {
        // Construtor que recebe a configura��o do DbContext
        public AluguelContext(DbContextOptions<AluguelContext> options) : base(options) { }

        // DbSet para a tabela de alugu�is (usando a classe Aluguel)
        public DbSet<Aluguel> Alugueis { get; set; }

        // Configura��o do modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definindo a chave prim�ria da entidade Aluguel
            modelBuilder.Entity<Aluguel>().HasKey(a => a.Id);

            // Configura��o adicional de propriedades
            modelBuilder.Entity<Aluguel>()
                .Property(a => a.LivroId)
                .IsRequired();

            modelBuilder.Entity<Aluguel>()
                .Property(a => a.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<Aluguel>()
                .Property(a => a.DataAluguel)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder.Entity<Aluguel>()
                .Property(a => a.DataDevolucao)
                .HasColumnType("datetime");

            modelBuilder.Entity<Aluguel>()
                .Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue("ativo");  // Definindo "ativo" como valor padr�o
        }
    }
}
