using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class CustomersReadDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string ClienteNombre { get; set; }

        [Display(Name = "Apellidos")]
        public string ClienteApellidos { get; set; }
    }
}
