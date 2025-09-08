
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Clientes : Registry
    {
        [Key]
        public string ClienteId { get; set; }
        [Required]
        public string ClienteNombre { get; set; }
        [Required]
        public string ClienteApellidos { get; set; }

        public int EstadosId { get; set; }
        public Estados Estados { get; set; }

        public int MunicipiosId { get; set; }
        public Municipios Municipios { get; set; }
    }
}
