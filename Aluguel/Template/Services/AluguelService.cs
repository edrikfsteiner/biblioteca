using Newtonsoft.Json;
using System.Text;
using Template.Context;
using Template.Models;
using Microsoft.EntityFrameworkCore;

namespace Template.Services
{
    public class AluguelService(AluguelContext context, HttpClient httpClient)
    {

        // Método para verificar a disponibilidade do livro no micro de Livro
        public async Task<bool> VerificarDisponibilidade(int livroId)
        {
            var response = await httpClient.GetAsync($"http://localhost:5090/api/Livro/{livroId}/disponibilidade?quantidade=1");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var disponibilidade = JsonConvert.DeserializeObject<dynamic>(result);
                return disponibilidade?.disponivel == true;
            }
            return false;
        }

        // Método para realizar o aluguel do livro
        public async Task<bool> RealizarAluguel(int livroId, int usuarioId)
        {
            // Verificar a disponibilidade do livro
            var disponivel = await VerificarDisponibilidade(livroId);
            if (!disponivel)
            {
                return false;
            }

            // Atualizar a disponibilidade do livro no micro de Livro (decrementar a quantidade)
            var updateResponse = await httpClient.PutAsync(
                $"http://localhost:5090/api/Livro/{livroId}/disponibilidade?quantidade=1",
                null // Método PUT sem body
            );

            if (updateResponse.IsSuccessStatusCode)
            {
                // Registrar o aluguel no banco de dados do micro de Aluguel
                var aluguel = new Aluguel
                {
                    LivroId = livroId,
                    UsuarioId = usuarioId,
                    DataAluguel = DateTime.UtcNow,
                    Status = "ativo"
                };

                context.Alugueis.Add(aluguel);
                await context.SaveChangesAsync();

                // Registrar a auditoria de aluguel
                var auditoriaResponse = await httpClient.PostAsync(
                    $"http://localhost:5092/api/Auditoria/registrar?livroId={livroId}&usuarioId={usuarioId}&acao=alugou",
                    null
                );

                if (!auditoriaResponse.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        // Método para obter todos os aluguéis
        public async Task<List<Aluguel>> ObterTodosAlugueis()
        {
            return await context.Alugueis.ToListAsync();
        }
    }
}
