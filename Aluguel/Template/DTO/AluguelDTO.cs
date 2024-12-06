namespace Template.DTO
{
    public class AluguelDTO
    {
        public int Id { get; set; }                // Identificador único do aluguel
        public int LivroId { get; set; }           // Referência ao livro alugado
        public int UsuarioId { get; set; }         // Identificação do usuário que realizou o aluguel
        public DateTime DataAluguel { get; set; }  // Data do aluguel
        public DateTime? DataDevolucao { get; set; } // Data de devolução (pode ser nula)
        public string Status { get; set; }         // Status do aluguel (ex: "ativo", "finalizado")
    }
}