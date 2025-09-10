using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class RegistryDTO
    {
        [Display(Name = "Etatus")]
        public bool Activo { get; set; } = true;

        [Display(Name = "Alta")]
        public DateTime HoraAlta { get; set; } = DateTime.Now;
    }
}
