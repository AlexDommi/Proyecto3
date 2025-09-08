namespace Proyecto3.Models
{
    public class Municipios : Registry
    {
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }

        public IEnumerable<Estados> Estados { get; set; }
        public IEnumerable<Clientes> Clientes { get; set; }
    }
}
