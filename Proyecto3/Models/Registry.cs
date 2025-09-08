namespace Proyecto3.Models
{
    public class Registry
    {
        public bool isActive { get; set; } = false;
        public bool isDeleted { get; set; } = false;

        public DateTime HighSystem { get; set; } = DateTime.Now;
    }
}
