using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    public class Auditoria
    {
        [Key]
        public int Id { get; set; }               // Identificador �nico do registro de auditoria

        [Required]
        public int LivroId { get; set; }          // Refer�ncia ao livro alugado

        [Required]
        public int UsuarioId { get; set; }        // Identifica��o do usu�rio que realizou o aluguel

        public DateTime DataAluguel { get; set; } // Data em que o aluguel foi realizado

        [Required]
        public string Acao { get; set; }          // A��o realizada (ex: "alugou", "devolveu")

        public DateTime? DataDevolucao { get; set; } // Data prevista/real de devolu��o (pode ser nula)
    }
}
