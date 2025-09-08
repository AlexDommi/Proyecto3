using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Contactos : Registry
    {
        [Key]
        public int ContactoId { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }

        // Navigation property for related Clientes
        public IEnumerable<Clientes> Clientes { get; set; }
    }
}
