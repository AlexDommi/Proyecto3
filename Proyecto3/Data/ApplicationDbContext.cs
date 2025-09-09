using Microsoft.EntityFrameworkCore;
using Proyecto3.Models;

namespace Proyecto3.Data
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customers> Clientes { get; set; }
        public DbSet<Contacts> Contactos { get; set; }
        public DbSet<Mails> Correos { get; set; }
        public DbSet<Direcciones> Direcciones { get; set; }
        public DbSet<Agreements> Acuerdos { get; set; }
        public DbSet<Followups> Seguimientos { get; set; }

    }
}
