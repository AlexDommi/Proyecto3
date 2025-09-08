using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Contactos : Registry
    {
        [Key]
        public int ContactoId { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }

        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }
    }
}
