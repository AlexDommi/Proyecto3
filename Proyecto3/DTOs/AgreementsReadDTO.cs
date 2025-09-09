using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto3.DTOs
{
    public class AgreementsReadDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public int ClientesId { get; set; }

        [Display(Name = "Pago")]
        public decimal AcuerdoPago { get; set; }

        [Display(Name = "Fecha")]
        public DateTime AcuerdoFecha { get; set; }

        public string Clientes { get; set; }
    }
}
