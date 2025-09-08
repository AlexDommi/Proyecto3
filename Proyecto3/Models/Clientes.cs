
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Clientes : Registry
    {
        public int Id { get; set; }
        [Required]
        public string ClienteNombre { get; set; }
        [Required]
        public string ClienteApellidos { get; set; }

        public IEnumerable<Acuerdos> Acuerdos { get; set; }
        public IEnumerable<Contactos> Contactos { get; set; }
        public IEnumerable<Correos> Correos { get; set; }
        public  IEnumerable<Direcciones> Direcciones { get; set; }
        public IEnumerable<Seguimientos> Seguimientos { get; set; }
    }
}
