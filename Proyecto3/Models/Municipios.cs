using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Models
{
    public class Municipios : Registry
    {
        [Key]
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }

    }
}
