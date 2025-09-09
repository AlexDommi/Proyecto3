using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Mails : Registry   
    {
        public int Id { get; set; }
        [Required]
        public string CorreoDireccion { get; set; }

        public int ClientesId { get; set; }
        public Customers Clientes { get; set; }
    }
}
