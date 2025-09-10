using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class MailsReadDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Correo")]
        public string CorreoDireccion { get; set; }

        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
