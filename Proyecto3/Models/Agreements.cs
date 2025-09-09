using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto3.Models
{
    public class Agreements : Registry
    {
        public int Id { get; set; }

        public int ClientesId { get; set; }
        public Customers Clientes { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AcuerdoPago { get; set; }

        [Required]
        public DateTime AcuerdoFecha { get; set; }

    }
}
