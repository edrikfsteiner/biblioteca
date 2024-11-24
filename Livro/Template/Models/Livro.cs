using System.ComponentModel.DataAnnotations;

namespace MicroserviceLivro.Template.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }               // Identificador �nico do livro
        public string Titulo { get; set; }         // T�tulo do livro
        public string Autor { get; set; }          // Autor do livro
        public string ISBN { get; set; }           // ISBN do livro
        public int NumeroDeCopias { get; set; }    // N�mero de c�pias do livro
        public string Status { get; set; }         // Status do livro (ex: "dispon�vel", "indispon�vel")
    }
}
