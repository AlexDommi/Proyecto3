using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class ContactsCreateDTO : RegistryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El telefono es requerido")]
        [Display(Name = "Telefono")]
        public string ContactoTelefono { get; set; }

        [Required(ErrorMessage = "El cliente requerido")]
        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
