using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Correos : Registry   
    {
        [Key]
        public int CorreoId { get; set; }
        [Required]
        public string CorreoDireccion { get; set; }
        
        public IEnumerable<Clientes> Clientes { get; set; }

        
    }
}
