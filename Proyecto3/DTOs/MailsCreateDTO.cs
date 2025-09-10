using Proyecto3.Models;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class MailsCreateDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Correo es requerido")]
        [Display(Name = "Correo")]
        public string CorreoDireccion { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
