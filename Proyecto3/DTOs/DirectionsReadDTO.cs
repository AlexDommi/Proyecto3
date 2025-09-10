using System.ComponentModel.DataAnnotations;

namespace Proyecto3.DTOs
{
    public class DirectionsReadDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Calle")]
        public string DireccionCalle { get; set; }

        [Display(Name = "EntreCalle1")]
        public string DireccionEntreCalle1 { get; set; }


        [Display(Name = "EntreCalle2")]
        public string DireccionEntreCalle2 { get; set; }

        [Display(Name = "CP")]
        public string DireccionCodigoPostal { get; set; }


        [Display(Name = "Colonia")]
        public string DireccionColonia { get; set; }

        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }
    }
}
