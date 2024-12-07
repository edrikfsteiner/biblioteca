using Microsoft.EntityFrameworkCore;
using Template.Context;
using Template.Models;

namespace Template.Services
{
    public class AuditoriaService(AuditoriaContext context)
    {

        // Método para registrar uma auditoria no banco de dados
        public async Task RegistrarAuditoria(int livroId, int usuarioId, string acao)
        {
            var auditoria = new Auditoria
            {
                LivroId = livroId,
                UsuarioId = usuarioId,
                Acao = acao,
                DataAluguel = DateTime.UtcNow,
                DataDevolucao = acao == "devolveu" ? DateTime.UtcNow : null
            };

            context.Auditorias.Add(auditoria);
            await context.SaveChangesAsync();
        }

        public async Task<List<Auditoria>> ObterTodasAuditorias()
        {
            return await context.Auditorias.ToListAsync();
        }

        // Método para obter uma auditoria específica por ID
        public async Task<Auditoria> ObterAuditoriaPorId(int id)
        {
            return await context.Auditorias.FindAsync(id);
        }
    }
}
