using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class ContactsReadDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string ContactoTelefono { get; set; }

        public int ClientesId { get; set; }
        public int Customers { get; set; }

    }
}
