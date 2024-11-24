using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.DTO;
using Template.Services;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        // Método para obter todos os livros
        [HttpGet]
        public async Task<IActionResult> ObterTodosLivros()
        {
            var livros = await _livroService.ObterTodosLivros();
            return Ok(livros);
        }

        // Método para obter um livro específico por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLivro(int id)
        {
            var livro = await _livroService.ObterLivroPorId(id);
            return livro == null ? NotFound() : Ok(livro);
        }

        // Método para verificar a disponibilidade de um livro
        [HttpGet("{id}/disponibilidade")]
        public async Task<IActionResult> VerificarDisponibilidade(int id, [FromQuery] int quantidade)
        {
            var disponivel = await _livroService.VerificarDisponibilidade(id, quantidade);
            return Ok(new { Disponivel = disponivel });
        }

        // Método para adicionar um novo livro
        [HttpPost]
        public async Task<IActionResult> AdicionarLivro([FromBody] LivroDTO livroDto)
        {
            var livro = await _livroService.AdicionarLivro(livroDto);
            return CreatedAtAction(nameof(ObterLivro), new { id = livro.Id }, livro);
        }
    }
}
