using MicroserviceLivro.Template.Models;
using Microsoft.EntityFrameworkCore;

namespace Template.Context
{
    public class LivroContext : DbContext
    {
        // Construtor que recebe a configuração do DbContext
        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }

        // DbSet para a tabela de livros (agora usando a classe Livro)
        public DbSet<Livro> Livros { get; set; }

        // Configuração do modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definindo a chave primária da entidade Livro
            modelBuilder.Entity<Livro>().HasKey(l => l.Id);

            // Configuração adicional de propriedades
            modelBuilder.Entity<Livro>()
                .Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Livro>()
                .Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Livro>()
                .Property(l => l.ISBN)
                .IsRequired()
                .HasMaxLength(13);

            modelBuilder.Entity<Livro>()
                .Property(l => l.NumeroDeCopias)
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Status)
                .IsRequired()
                .HasDefaultValue("disponível");  // Definindo "disponível" como valor padrão
        }
    }
}
