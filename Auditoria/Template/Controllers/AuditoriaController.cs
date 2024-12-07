using Microsoft.AspNetCore.Mvc;
using Template.Services;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController(AuditoriaService auditoriaService) : ControllerBase
    {

        // Endpoint para registrar uma auditoria de "aluguel" ou "devolução"
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarAuditoria([FromQuery] int livroId, [FromQuery] int usuarioId, [FromQuery] string acao)
        {
            if (acao != "alugou" && acao != "devolveu")
            {
                return BadRequest(new { Mensagem = "Ação inválida. Use 'alugou' ou 'devolveu'." });
            }

            await auditoriaService.RegistrarAuditoria(livroId, usuarioId, acao);
            return Ok(new { Mensagem = $"Auditoria de '{acao}' registrada com sucesso." });
        }

        // Método para obter todas as auditorias
        [HttpGet]
        public async Task<IActionResult> ObterTodasAuditorias()
        {
            var auditorias = await auditoriaService.ObterTodasAuditorias();
            return Ok(auditorias);
        }
    }
}
