namespace Template.DTO
{
    public class LivroDTO
    {
        public int Id { get; set; }               // Identificador único do livro
        public string Titulo { get; set; }         // Título do livro
        public string Autor { get; set; }          // Autor do livro
        public string ISBN { get; set; }           // ISBN do livro
        public int NumeroDeCopias { get; set; }    // Número de cópias do livro
        public string Status { get; set; }         // Status do livro (ex: "disponível", "indisponível")
    }
}
