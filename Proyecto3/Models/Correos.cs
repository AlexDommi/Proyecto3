using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Correos : Registry   
    {
        [Key]
        public int CorreoId { get; set; }
        [Required]
        public string CorreoDireccion { get; set; }
        
        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }
    }
}
