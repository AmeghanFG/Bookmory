using System.ComponentModel.DataAnnotations;

namespace Bookmory.Data
{
    public class Genero
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Genero_txt { get; set; }
        virtual public List<Libro> Libros { get; set; }
    }
}
