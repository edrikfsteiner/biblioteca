using System;

namespace Template.DTO
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }                // Identificador único do registro de auditoria
        public int LivroId { get; set; }           // Referência ao livro que foi alugado
        public int UsuarioId { get; set; }         // Identificação do usuário que realizou o aluguel
        public DateTime DataAluguel { get; set; }  // Data do aluguel
        public DateTime? DataDevolucao { get; set; } // Data de devolução (pode ser nula)
        public string Acao { get; set; }           // Ação realizada (ex: "alugado")
    }
}
