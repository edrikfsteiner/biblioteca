using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }               // Identificador �nico do aluguel

        [Required]
        public int LivroId { get; set; }          // Refer�ncia ao livro alugado

        [Required]
        public int UsuarioId { get; set; }        // Identifica��o do usu�rio que realizou o aluguel

        [Required]
        public DateTime DataAluguel { get; set; } // Data em que o aluguel foi realizado

        public DateTime? DataDevolucao { get; set; } // Data prevista/real de devolu��o (pode ser nula)

        [Required]
        public string Status { get; set; } = "ativo"; // Status do aluguel (ex: "ativo", "finalizado")
    }
}
