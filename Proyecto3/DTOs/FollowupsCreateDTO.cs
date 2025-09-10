using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class FollowupsCreateDTO : RegistryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha")]
        public DateTime SeguimientoFecha { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [Display(Name = "Descripcion")]
        public string SeguimientoDescripcion { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
