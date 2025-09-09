using Proyecto3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto3.DTOs
{
    public class AgreementsCreateDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Clientes")]
        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        public int ClientesId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AcuerdoPago { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una fecha")]
        public DateTime AcuerdoFecha { get; set; }
    }
}
