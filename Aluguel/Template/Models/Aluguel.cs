using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }               // Identificador único do aluguel

        [Required]
        public int LivroId { get; set; }          // Referência ao livro alugado

        [Required]
        public int UsuarioId { get; set; }        // Identificação do usuário que realizou o aluguel

        [Required]
        public DateTime DataAluguel { get; set; } // Data em que o aluguel foi realizado

        public DateTime? DataDevolucao { get; set; } // Data prevista/real de devolução (pode ser nula)

        [Required]
        public string Status { get; set; } = "ativo"; // Status do aluguel (ex: "ativo", "finalizado")
    }
}
