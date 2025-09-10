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
        [Display(Name = "Entre Calle 1")]
        public string DireccionEntreCalle1 { get; set; }

        [Required(ErrorMessage = "La entre calle 2 es requerida")]
        [Display(Name = "Entre Calle 2")]
        public string DireccionEntreCalle2 { get; set; }

        [Required(ErrorMessage = "El código postal es requerido")]
        [Display(Name = "Código Postal")]
        public string DireccionCodigoPostal { get; set; }

        [Required(ErrorMessage = "La colonia es requerida")]
        [Display(Name = "Colonia")]
        public string DireccionColonia { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }

        public IEnumerable<CustomersReadDTO> Clientes { get; set; } = new List<CustomersReadDTO>();
    }
}
