using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Seguimientos : Registry
    {
        [Key]
        public int SeguimientoId { get; set; }
        public DateTime SeguimientoFecha { get; set; }
        public string SeguimientoDescripcion { get; set; }

        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }
    }
}
