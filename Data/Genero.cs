namespace Bookmory.Data
{
    public class Genero
    {
        public int Id { get; set; }
        public string Genero_txt { get; set; }
        virtual public List<Libro> Libros { get; set; }
    }
}
