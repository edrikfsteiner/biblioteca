using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    public class Auditoria
    {
        [Key]
        public int Id { get; set; }               // Identificador único do registro de auditoria

        [Required]
        public int LivroId { get; set; }          // Referência ao livro alugado

        [Required]
        public int UsuarioId { get; set; }        // Identificação do usuário que realizou o aluguel

        public DateTime DataAluguel { get; set; } // Data em que o aluguel foi realizado

        [Required]
        public string Acao { get; set; }          // Ação realizada (ex: "alugou", "devolveu")

        public DateTime? DataDevolucao { get; set; } // Data prevista/real de devolução (pode ser nula)
    }
}
