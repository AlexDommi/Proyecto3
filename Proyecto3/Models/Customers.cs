
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Customers : Registry
    {
        public int Id { get; set; }
        [Required]
        public string ClienteNombre { get; set; }
        [Required]
        public string ClienteApellidos { get; set; }

        public IEnumerable<Agreements> Acuerdos { get; set; }
        public IEnumerable<Contacts> Contactos { get; set; }
        public IEnumerable<Mails> Correos { get; set; }
        public  IEnumerable<Directions> Direcciones { get; set; }
        public IEnumerable<Followups> Seguimientos { get; set; }
    }
}
