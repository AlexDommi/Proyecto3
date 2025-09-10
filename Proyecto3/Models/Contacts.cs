using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Contacts : Registry
    {
        public int Id { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }

        public int ClientesId { get; set; }
        public Customers Clientes { get; set; }

    }
}
