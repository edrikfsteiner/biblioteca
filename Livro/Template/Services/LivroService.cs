using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MicroserviceLivro.Infra;
using MicroserviceLivro.Template.Models;
using Template.DTO;
using Template.Context;

namespace Template.Services
{
    public class LivroService
    {
        private readonly LivroContext _context;

        public LivroService(LivroContext context)
        {
            _context = context;
        }

        // Método para obter todos os livros
        public async Task<List<Livro>> ObterTodosLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        // Método para obter um livro por ID
        public async Task<Livro> ObterLivroPorId(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        // Método para verificar a disponibilidade do livro
        public async Task<bool> VerificarDisponibilidade(int livroId, int quantidade)
        {
            var livro = await _context.Livros.FindAsync(livroId);
            return livro != null && livro.NumeroDeCopias >= quantidade;
        }

        // Método para adicionar um novo livro
        public async Task<Livro> AdicionarLivro(LivroDTO livroDto)
        {
            var livro = new Livro
            {
                Titulo = livroDto.Titulo,
                Autor = livroDto.Autor,
                ISBN = livroDto.ISBN,
                NumeroDeCopias = livroDto.NumeroDeCopias,
                Status = livroDto.Status
            };

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
    }
}
