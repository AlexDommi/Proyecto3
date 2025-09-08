using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Estados : Registry
    {
        [Key]
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }

        public int MunicipiosId { get; set; }
        public Municipios Municipios { get; set; }
    }
}
