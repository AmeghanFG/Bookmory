using System.ComponentModel.DataAnnotations;

namespace Bookmory.Data
{
    public class Editorial
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        virtual public List<Libro> Libros { get; set; }
    }
}
