using Template.Models;
using Microsoft.EntityFrameworkCore;

namespace Template.Context
{
    public class AuditoriaContext : DbContext
    {
        // Construtor que recebe a configura��o do DbContext
        public AuditoriaContext(DbContextOptions<AuditoriaContext> options) : base(options) { }

        // DbSet para a tabela de auditorias (agora usando a classe Auditoria)
        public DbSet<Auditoria> Auditorias { get; set; }

        // Configura��o do modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definindo a chave prim�ria da entidade Auditoria
            modelBuilder.Entity<Auditoria>().HasKey(a => a.Id);

            // Configura��o adicional de propriedades
            modelBuilder.Entity<Auditoria>()
                .Property(a => a.LivroId)
                .IsRequired();

            modelBuilder.Entity<Auditoria>()
                .Property(a => a.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<Auditoria>()
                .Property(a => a.DataAluguel)
                .HasColumnType("datetime");

            modelBuilder.Entity<Auditoria>()
                .Property(a => a.Acao)
                .IsRequired()
                .HasMaxLength(50); // Ajuste o tamanho conforme necess�rio

            modelBuilder.Entity<Auditoria>()
                .Property(a => a.DataDevolucao)
                .HasColumnType("datetime");
        }
    }
}
