using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Estados : Registry
    {
        [Key]
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }

        public int MunicipioId { get; set; }
        public Municipios Municipio { get; set; }

        public IEnumerable<Clientes> Clientes { get; set; }
    }
}
