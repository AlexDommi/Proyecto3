using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Contactos : Registry
    {
        public int Id { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }

        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }


    }
}
