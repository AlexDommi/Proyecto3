
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Clientes : Registry
    {
        [Key]
        public string ClienteId { get; set; }
        [Required]
        public string ClienteNombre { get; set; }
        [Required]
        public string ClienteApellidos { get; set; }

        // Foreign key to Direcciones
        public int DireccionId { get; set; }
        public Direcciones Direccion { get; set; }

        // Foreign key to Contactos
        public int ContactoId { get; set; }
        public Contactos Contacto { get; set; }
        
        // Foreign key to Correos
        public int CorreoId { get; set; }
        public Correos Correos { get; set; }

        // Foreign key to Seguimientos
        public int SeguimientoId { get; set; }
        public Seguimientos Seguimiento { get; set; }
    }
}
