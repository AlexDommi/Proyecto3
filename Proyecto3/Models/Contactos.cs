using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Contactos : Registry
    {
        public int ContactoId { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }

        public IEnumerable<Clientes> Clientes { get; set; }
    }
}
