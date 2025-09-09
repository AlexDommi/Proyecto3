using Proyecto3.Models;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class CustomersCreatedDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string ClienteNombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string ClienteApellidos { get; set; }

    }
}
