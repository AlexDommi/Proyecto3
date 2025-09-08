namespace Proyecto3.Models
{
    public class Seguimientos : Registry
    {
        public int SeguimientoId { get; set; }
        public DateTime SeguimientoFecha { get; set; }
        public string SeguimientoDescripcion { get; set; }

        public IEnumerable<Clientes> Clientes { get; set; }

    }
}
