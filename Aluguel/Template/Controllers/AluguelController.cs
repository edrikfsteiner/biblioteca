using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Services;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController(AluguelService aluguelService) : ControllerBase
    {

        // Método para verificar a disponibilidade de um livro
        [HttpGet("{id}/disponibilidade")]
        public async Task<IActionResult> VerificarDisponibilidade(int id)
        {
            var disponivel = await aluguelService.VerificarDisponibilidade(id);
            return Ok(new { Disponivel = disponivel });
        }

        // Método para realizar o aluguel de um livro
        [HttpPost("{id}/alugar")]
        public async Task<IActionResult> AlugarLivro(int id, [FromQuery] int usuarioId)
        {
            var sucesso = await aluguelService.RealizarAluguel(id, usuarioId);
            if (sucesso)
            {
                return Ok(new { Mensagem = "Aluguel realizado com sucesso." });
            }
            else
            {
                return BadRequest(new { Mensagem = "Falha ao realizar o aluguel. Livro não disponível." });
            }
        }

        // Método para obter todos os aluguéis (GET geral)
        [HttpGet]
        public async Task<IActionResult> ObterTodosAlugueis()
        {
            var aluguels = await aluguelService.ObterTodosAlugueis();
            return Ok(aluguels);
        }
    }
}
