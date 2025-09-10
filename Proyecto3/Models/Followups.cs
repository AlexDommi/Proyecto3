using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Followups : Registry
    {
        public int Id { get; set; }
        public DateTime SeguimientoFecha { get; set; }
        public string SeguimientoDescripcion { get; set; }

        public int ClientesId { get; set; }
        public Customers Clientes { get; set; }
    }
}
