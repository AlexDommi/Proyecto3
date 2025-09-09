using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class DirectionsCreateDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La calle es requerida")]
        [Display(Name = "Calle")]
        public string DireccionCalle { get; set; }

        [Required(ErrorMessage = "La entre calle 1 es requerida")]
        [Display(Name = "EntreCalle1")]
        public string DireccionEntreCalle1 { get; set; }

        [Required(ErrorMessage = "La entre calle 2 es requerida")]
        [Display(Name = "EntreCalle2")]
        public string DireccionEntreCalle2 { get; set; }

        [Required(ErrorMessage = "El codigo postal")]
        [Display(Name = "CP")]
        public string DireccionCodigoPostal { get; set; }

        [Required(ErrorMessage = "La colonia es requerida")]
        [Display(Name = "Colonia")]
        public string DireccionColonia { get; set; }

        [Required(ErrorMessage = "El clientes es requerido")]
        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
