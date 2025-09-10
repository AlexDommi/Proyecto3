using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Directions : Registry
    {
        public int Id { get; set; }
        [Required]
        public string DireccionCalle { get; set; }
        public string DireccionEntreCalle1 { get; set; }
        [Required]
        public string DireccionEntreCalle2 { get; set; }
        [Required]
        public string DireccionCodigoPostal { get; set; }
        [Required]
        public string DireccionColonia { get; set; }

        public int ClientesId { get; set; }
        public Customers Clientes { get; set; }
    }


}
