using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Direcciones : Registry
    {
        [Key]
        public int DireccionId { get; set; }
        [Required]
        public string DireccionCalle { get; set; }
        public string DireccionEntreCalle1 { get; set; }
        [Required]
        public string DireccionEntreCalle2 { get; set; }
        [Required]
        public string DireccionCodigoPostal { get; set; }
        [Required]
        public string DireccionColonia { get; set; }

        public IEnumerable<Clientes> Clientes { get; set; }
        public IEnumerable<Estados> Estados { get; set; }
        public IEnumerable<Municipios> Municipios { get; set; }
    }
}
