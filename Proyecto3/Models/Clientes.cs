
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Clientes : Registry
    {
        public string ClienteId { get; set; }
        [Required]
        public string ClienteNombre { get; set; }
        [Required]
        public string ClienteApellidos { get; set; }
        
        public int DireccionId { get; set; }
        public Direcciones Direccion { get; set; }

        public int ContactoId { get; set; }
        public Contactos Contacto { get; set; }

        public int CorreoId { get; set; }
        public Correos Correos { get; set; }

        public int SeguimientoId { get; set; }
        public Seguimientos Seguimiento { get; set; }
    }
}
