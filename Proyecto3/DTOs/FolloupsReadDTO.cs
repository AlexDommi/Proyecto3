using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class FolloupsReadDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime SeguimientoFecha { get; set; }
        
        [Display(Name = "Descripcion")]
        public string SeguimientoDescripcion { get; set; }

        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
